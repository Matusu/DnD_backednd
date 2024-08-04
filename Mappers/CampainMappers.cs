using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class CampainMappers
{
    static public CampainDto ToCampainDto(this Campain campain)
    {
        return new CampainDto
        {
            Name = campain.Name,
            UserId = campain.UserId,
        };
    }
    static public Campain ToCampainFromCreate(this CreateCampainDto createCampainDto, string UserId)
    {
        return new Campain
        {
            Name = createCampainDto.Name,
            UserId = UserId,
        };
    }
}