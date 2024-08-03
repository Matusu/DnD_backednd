using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;

[Route("webapi/[Controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly IClassRepository _classRepo;
    public ClassController(IClassRepository classRepo)
    {
        _classRepo = classRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var classes = await _classRepo.GetAllAsync();
        var classDto = classes.Select(c => c.ToClassDto());
        return Ok(classDto);
    }
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetById([FromRoute] int id)
    // {
    //     var classModel = await _classRepo.GetByIdAsync(id);
    //     if (classModel == null)
    //         return NotFound();
    //     return Ok(classModel.ToClassDto());
    // }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClassSpells([FromRoute] int id)
    {
        var spellsModel = await _classRepo.GetClassSpells(id);
        if (spellsModel == null)
            return BadRequest("No spells");
        var spellsDto = spellsModel.Select(s => s.ToSpellDto());
        return Ok(spellsDto);
    }
    [HttpPost]
    public async Task<IActionResult> AddClass([FromBody] AddClass classDto)
    {
        var classModel = await _classRepo.AddClassAsync(classDto);
        if (classModel == null)
            return BadRequest("Class allready exists");
        // return CreatedAtAction(nameof(GetById), new { id = classModel.Id }, classModel.ToClassDto());
        return Ok(classModel);
    }
}
