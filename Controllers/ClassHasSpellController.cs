using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;
[ApiController]
[Route("webapi/[Controller]")]
public class ClassHasSpellController : ControllerBase
{
    private readonly IClassHasSpellRepository _classHasSpellRepo;
    public ClassHasSpellController(IClassHasSpellRepository classHasSpellRepo)
    {
        _classHasSpellRepo = classHasSpellRepo;
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var classHasSpellModel = await _classHasSpellRepo.GetAllAsync();
        var classHasSpellDto = classHasSpellModel.Select(c => c.ToClassHasSpellDto());
        return Ok(classHasSpellDto);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddSpellToClass([FromBody] AddSpellToClassDto addSpellToClassDto)
    {
        var classHasSpell = await _classHasSpellRepo.AddSpellToClassAsync(addSpellToClassDto);
        return Ok(classHasSpell);
    }
}