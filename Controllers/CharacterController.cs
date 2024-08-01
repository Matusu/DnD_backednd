using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;

[Route("webapi/[Controller]")]
[ApiController]
class CharacterController : ControllerBase
{
    private readonly ICharacterRepository _characterRepo;
    public CharacterController(ICharacterRepository characterRepo)
    {
        _characterRepo = characterRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var character = await _characterRepo.GetAllAsync();
        var characterDto = character.Select(s => s.ToCharacterDto());
        return Ok(characterDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var character = await _characterRepo.GetByIdAsync(id);
        if (character == null)
        {
            return NotFound();
        }
        return Ok(character.ToCharacterDto());
    }
}