using Microsoft.AspNetCore.Http.HttpResults;
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
}
