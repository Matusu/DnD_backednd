using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface IClassRepository
{
    Task<List<Class>> GetAllAsync();
    Task<Class?> GetByIdAsync(int id);
    Task<Class?> AddClassAsync(AddClass classDto);
    Task<List<Spell>?> GetClassSpellsAsync(int classId);
}