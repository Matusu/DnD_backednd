using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface ICharacterRepository
{
    Task<List<Character>> GetAllAsync();
    Task<Character?> CreateCharacterAsync(AddCharacterDto addCharacterDto);
    Task<List<Feature>?> GetCharacterFeatureAsync(int id);
    Task<List<Spell>?> GetCharacterSpellAsync(int id);
    Task<List<Spell>?> GetPreparedCharacterSpellAsync(int id);
}