using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class ClassHasSpellRepository : IClassHasSpellRepository
{
    private readonly ApplicationDbContext _context;
    public ClassHasSpellRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ClassHasSpell> AddSpellToClassAsync(AddSpellToClassDto addSpellToClassDto)
    {
        var classHasSpellModel = addSpellToClassDto.ToClassHasSpellFromCreate();
        await _context.ClassHasSpells.AddAsync(classHasSpellModel);
        await _context.SaveChangesAsync();
        return classHasSpellModel;
    }

    public async Task<List<ClassHasSpell>> GetAllAsync()
    {
        return await _context.ClassHasSpells.ToListAsync();
    }

    public async Task<List<ClassHasSpell>> GetClassSpellsAsync(int classId)
    {
        return await _context.ClassHasSpells.Where(c => c.ClassId == classId).Include(c => c.Spell).ToListAsync();
    }
}