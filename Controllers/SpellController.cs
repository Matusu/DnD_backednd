using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;
[ApiController]
[Route("webapi/[Controller]")]
public class SpellController : ControllerBase
{
    private readonly ISpellRepository _spellRepo;
    public SpellController(ISpellRepository spellRepo)
    {
        _spellRepo = spellRepo;
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var spells = await _spellRepo.GetAllAsync();
        var spellsDto = spells.Select(s => s.ToSpellDto());
        return Ok(spellsDto);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddSpell([FromBody] AddSpellDto addSpellDto)
    {
        var spellModel = await _spellRepo.AddSpellAsync(addSpellDto);
        if (spellModel == null)
            return BadRequest("Spell allready exists");
        return Ok(spellModel);
    }
}