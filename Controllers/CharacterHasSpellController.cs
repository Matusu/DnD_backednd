using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;
[ApiController]
[Route("webapi/[Controller]")]
public class CharacterHasSpellController : ControllerBase
{
    private readonly ICharacterHasSpellRepository _characterHasSpellRepo;
    public CharacterHasSpellController(ICharacterHasSpellRepository characterHasSpellRepo)
    {
        _characterHasSpellRepo = characterHasSpellRepo;
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var characterHasSpellModel = await _characterHasSpellRepo.GetAllAsync();
        var characterHasSpellDto = characterHasSpellModel.Select(c => c.ToCharacterHasSpellDto());
        return Ok(characterHasSpellDto);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddSpellToCharacter(AddSpellToCharacterDto addSpellToCharacterDto)
    {
        var characterHasSpell = await _characterHasSpellRepo.AddSpellToCharacterAsync(addSpellToCharacterDto);
        return Ok(characterHasSpell);
    }
}