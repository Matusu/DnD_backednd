using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface IHasFeatureRepository
{
    Task<List<HasFeature>> GetCharacterFeaturesAsync(int classId, int raceId);
    Task<HasFeature> AddFeatureLinkAsync(HasFeatureDto hasFeatureDto);
}