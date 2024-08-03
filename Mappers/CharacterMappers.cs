using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class CharacterMappers
{
    public static CharacterDto ToCharacterDto(this Character characterModel)
    {
        return new CharacterDto
        {
            Id = characterModel.Id,
            Name = characterModel.Name,
            RaceId = characterModel.RaceId,
            ClassId = characterModel.ClassId,
            CampainId = characterModel.CampainId,
            UserId = characterModel.UserId,
            Streangth = characterModel.Streangth,
            Dexterity = characterModel.Dexterity,
            Intelligence = characterModel.Intelligence,
            Wisdom = characterModel.Wisdom,
            Constitution = characterModel.Constitution,
            Charisma = characterModel.Charisma
        };
    }
    public static Character ToCharacterFromCreate(this AddCharacterDto characterDto)
    {
        return new Character
        {
            Name = characterDto.Name,
            RaceId = characterDto.RaceId,
            ClassId = characterDto.ClassId,
            CampainId = characterDto.CampainId,
            UserId = characterDto.UserId,
            Streangth = characterDto.Streangth,
            Dexterity = characterDto.Dexterity,
            Intelligence = characterDto.Intelligence,
            Wisdom = characterDto.Wisdom,
            Constitution = characterDto.Constitution,
            Charisma = characterDto.Charisma
        };
    }
}