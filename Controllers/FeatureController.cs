using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;
[ApiController]
[Route("webapi/[Controller]")]
public class FeatureController : ControllerBase
{
    private readonly IFeatureRepository _featureRepo;
    public FeatureController(IFeatureRepository featureRepo)
    {
        _featureRepo = featureRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var feature = await _featureRepo.GettAllAsync();
        var featureDto = feature.Select(f => f.ToFeatureDto());
        return Ok(featureDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var feature = await _featureRepo.GetByIdAsync(id);
        if (feature == null)
            return NotFound();
        return Ok(feature.ToFeatureDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewFeature([FromBody] AddFeature featureDto)
    {
        var featureModel = await _featureRepo.CreateFeatureAsync(featureDto);
        if (featureModel == null)
            return BadRequest("Feature allready exists");
        return CreatedAtAction(nameof(GetById), new { id = featureModel.Id }, featureModel.ToFeatureDto());
    }
}