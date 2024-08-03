using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface ISpellRepository
{
    public Task<List<Spell>> GetAllAsync();
    public Task<Spell?> AddSpellAsync(AddSpellDto addSpellDto);
}