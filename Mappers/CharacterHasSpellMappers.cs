using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class CharacterHasSpellMappers
{
    public static CharacterHasSpell ToCharacterHasSpell(this AddSpellToCharacterDto addSpellToCharacterDto)
    {
        return new CharacterHasSpell
        {
            CharacterId = addSpellToCharacterDto.CharacterId,
            SpellId = addSpellToCharacterDto.SpellId,
            Prepared = addSpellToCharacterDto.Prepared
        };
    }
    public static CharacterHasSpellDto ToCharacterHasSpellDto(this CharacterHasSpell characterHasSpell)
    {
        return new CharacterHasSpellDto
        {
            CharacterId = characterHasSpell.CharacterId,
            SpellId = characterHasSpell.SpellId,
            Prepared = characterHasSpell.Prepared
        };
    }
}