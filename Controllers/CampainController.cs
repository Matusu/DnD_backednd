using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Repository;

namespace webapi.Controllers;

[Route("webapi/[Controller]")]
[ApiController]
public class CampainController : ControllerBase
{
    private readonly ICampainRepository _campainRepo;
    private readonly IUserRepository _userRepo;
    public CampainController(ICampainRepository campainRepo, IUserRepository userRepo)
    {
        _campainRepo = campainRepo;
        _userRepo = userRepo;
    }
    [HttpGet]
    public async Task<IActionResult> Getall()
    {
        var campainModel = await _campainRepo.GetAllAsync();
        var campainDto = campainModel.Select(x => x.ToCampainDto());
        return Ok(campainDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var camapinModel = await _campainRepo.GetByIdAsync(id);
        if (camapinModel == null)
        {
            return NotFound();
        }
        return Ok(camapinModel.ToCampainDto());
    }
    [HttpPost("{UserId}")]
    public async Task<IActionResult> CreateCampain([FromRoute] int UserId, [FromBody] CreateCampainDto campainDto)
    {
        if (!await _userRepo.UserExists(UserId))
        {
            return BadRequest("User neexistuje");
        }
        var campain = campainDto.ToCampainFromCreate(UserId);
        var campainModel = await _campainRepo.CreateAsync(campain);
        return CreatedAtAction(nameof(GetById), new { id = campainModel.Id }, campainModel.ToCampainDto());
    }
}