using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Controllers;
[ApiController]
[Route("webapi/[Controller]")]
public class HasFeatureController : ControllerBase
{
    private readonly IHasFeatureRepository _hasFeatureRepo;
    public HasFeatureController(IHasFeatureRepository hasFeatureRepo)
    {
        _hasFeatureRepo = hasFeatureRepo;
    }
    [HttpGet("{classId} {raceId}")]
    [Authorize]
    public async Task<IActionResult> GetAllFeatures([FromRoute] int classId, [FromRoute] int raceId)
    {
        var features = await _hasFeatureRepo.GetCharacterFeaturesAsync(classId, raceId);
        var featuresDto = features.Select(f => f.Feature != null ? f.Feature.ToFeatureDto() : new FeatureDto { });
        return Ok(featuresDto);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddFeatureLink(HasFeatureDto hasFeatureDto)
    {
        var hasFeatureModel = await _hasFeatureRepo.AddFeatureLinkAsync(hasFeatureDto);
        return Ok(hasFeatureModel);
    }
}