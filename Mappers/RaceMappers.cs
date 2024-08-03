using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class RaceMappers
{
    public static RaceDto ToRaceDto(this Race raceModel)
    {
        return new RaceDto
        {
            Name = raceModel.Name,
        };
    }
    public static Race ToRaceFromCreate(this AddRace raceDto)
    {
        return new Race
        {
            Name = raceDto.Name
        };
    }
}