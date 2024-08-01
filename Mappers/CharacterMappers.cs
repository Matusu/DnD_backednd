using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

static public class CharacterMappers
{
    static public CharacterDto ToCharacterDto(this Character characterModel)
    {
        return new CharacterDto
        {
            Name = characterModel.Name,
            UserId = characterModel.UserId,
        };
    }
}