using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface IClassHasSpellRepository
{
    Task<List<ClassHasSpell>> GetAllAsync();
    Task<ClassHasSpell> AddSpellToClassAsync(AddSpellToClassDto addSpellToClassDto);
    Task<List<ClassHasSpell>> GetClassSpellsAsync(int classId);
}