using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Mappers;
using webapi.Repository;

namespace webapi.Controllers;
[Route("webapi/[Controller]")]
[ApiController]
public class RaceController : ControllerBase
{
    private readonly IRaceRepository _raceRepo;
    public RaceController(IRaceRepository raceRepo)
    {
        _raceRepo = raceRepo;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var race = await _raceRepo.GetAllAsync();
        var raceDto = race.Select(r => r.ToRaceDto());
        return Ok(raceDto);
    }
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var race = await _raceRepo.GetByIdAsync(id);
        if (race == null)
            return NotFound();
        return Ok(race.ToRaceDto());
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddRace([FromBody] AddRace raceDto)
    {
        var race = await _raceRepo.AddRaceAsync(raceDto);
        if (race == null)
            return BadRequest("Race allready exists");
        return CreatedAtAction(nameof(GetById), new { id = race.Id }, race.ToRaceDto());
    }

}