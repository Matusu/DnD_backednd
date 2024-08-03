using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class FeatureMappers
{
    public static FeatureDto ToFeatureDto(this Feature featureModel)
    {
        return new FeatureDto
        {
            Name = featureModel.Name,
            Description = featureModel.Description,
        };
    }
    public static Feature ToFeatureFromCreate(this AddFeature featureDto)
    {
        return new Feature
        {
            Name = featureDto.Name,
            Description = featureDto.Description,
        };
    }
}