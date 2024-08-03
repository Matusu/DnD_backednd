using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class HasFeatureMappers
{
    public static HasFeature ToHasFeatureModel(this HasFeatureDto hasFeatureDto)
    {
        return new HasFeature
        {
            RaceId = hasFeatureDto.RaceId,
            ClassId = hasFeatureDto.ClassId,
            FeatureId = hasFeatureDto.FeatureId
        };
    }
}