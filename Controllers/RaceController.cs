using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetAll()
    {
        var race = await _raceRepo.GetAllAsync();
        var raceDto = race.Select(r => r.ToRaceDto());
        return Ok(raceDto);
    }

}