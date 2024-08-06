using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;
[Route("webapi/[Controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterRepository _characterRepo;
    public CharacterController(ICharacterRepository characterRepo)
    {
        _characterRepo = characterRepo;
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var characterModel = await _characterRepo.GetAllAsync();
        var characterDto = characterModel.Select(c => c.ToCharacterDto());
        return Ok(characterDto);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCharacter([FromBody] AddCharacterDto addCharacterDto)
    {
        var character = await _characterRepo.CreateCharacterAsync(addCharacterDto);
        if (character == null)
            return BadRequest("Character allready Exists");
        return Ok(character);
    }
    [HttpGet("{id}")]
    [Authorize]
    // public async Task<IActionResult> GetCaracterFeatures([FromRoute] int id)
    // {
    //     var features = await _characterRepo.GetCharacterFeatureAsync(id);
    //     if (features == null)
    //         return BadRequest("No features found");
    //     var featuresDto = features.Select(f => f.ToFeatureDto());
    //     return Ok(featuresDto);
    // }
    // public async Task<IActionResult> GetCaracterSpell([FromRoute] int id)
    // {
    //     var spells = await _characterRepo.GetCharacterSpellAsync(id);
    //     if (spells == null)
    //         return BadRequest("No spells found");
    //     var spellDto = spells.Select(s => s.ToSpellDto());
    //     return Ok(spellDto);
    // }
    public async Task<IActionResult> GetCaracterSpell([FromRoute] int id)
    {
        var spells = await _characterRepo.GetPreparedCharacterSpellAsync(id);
        if (spells == null)
            return BadRequest("No spells found");
        var spellDto = spells.Select(s => s.ToSpellDto());
        return Ok(spellDto);
    }
}