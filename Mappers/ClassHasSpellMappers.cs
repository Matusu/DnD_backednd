using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class ClassHasSpellMappers
{
    public static ClassHasSpellDto ToClassHasSpellDto(this ClassHasSpell classHasSpell)
    {
        return new ClassHasSpellDto
        {
            SpellId = classHasSpell.SpellId,
            ClassId = classHasSpell.ClassId
        };
    }
    public static ClassHasSpell ToClassHasSpellFromCreate(this AddSpellToClassDto addSpellToClassDto)
    {
        return new ClassHasSpell
        {
            SpellId = addSpellToClassDto.SpellId,
            ClassId = addSpellToClassDto.ClassId
        };
    }
}