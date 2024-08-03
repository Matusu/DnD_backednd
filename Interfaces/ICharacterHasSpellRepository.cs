using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface ICharacterHasSpellRepository
{
    Task<List<CharacterHasSpell>> GetAllAsync();
    Task<List<CharacterHasSpell>> GetCharacterSpellsAsync(int id);
    Task<List<CharacterHasSpell>> GetPreparedCharacterSpellAsync(int id);
    Task<CharacterHasSpell> AddSpellToCharacterAsync(AddSpellToCharacterDto addSpellToCharacterDto);
}