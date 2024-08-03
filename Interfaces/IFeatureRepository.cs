using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface IFeatureRepository
{
    Task<List<Feature>> GettAllAsync();
    Task<Feature?> GetByIdAsync(int id);
    Task<Feature?> CreateFeatureAsync(AddFeature featureDto);
}