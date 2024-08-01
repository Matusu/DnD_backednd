using webapi.Models;

namespace webapi.Interfaces;

public interface ICharacterRepository
{
    Task<List<Character>> GetAllAsync();
    Task<Character?> GetByIdAsync(int id);
}