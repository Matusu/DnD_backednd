using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Controllers;

[Route("webapi/[Controller]")]
[ApiController]
public class CampainController : ControllerBase
{
    private readonly ICampainRepository _campainRepo;
    private readonly UserManager<appUser> _userManager;
    public CampainController(ICampainRepository campainRepo, UserManager<appUser> userManager)
    {
        _campainRepo = campainRepo;
        _userManager = userManager;
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
    public async Task<IActionResult> CreateCampain([FromRoute] string UserId, [FromBody] CreateCampainDto campainDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == UserId);
        if (user == null)
        {
            return BadRequest("User neexistuje");
        }
        var campain = campainDto.ToCampainFromCreate(UserId);
        var campainModel = await _campainRepo.CreateAsync(campain);
        return CreatedAtAction(nameof(GetById), new { id = campainModel.Id }, campainModel.ToCampainDto());
    }
}