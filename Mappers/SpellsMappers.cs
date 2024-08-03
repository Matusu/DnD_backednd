using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class SpellsMappers
{
    public static SpellDto ToSpellDto(this Spell spell)
    {
        return new SpellDto
        {
            Name = spell.Name,
            Id = spell.Id,
            Description = spell.Description,
        };
    }
    public static Spell ToSpellFromCreate(this AddSpellDto addSpellDto)
    {
        return new Spell
        {
            Name = addSpellDto.Name,
            Description = addSpellDto.Description,
        };
    }
}