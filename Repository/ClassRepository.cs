using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class ClassRepository : IClassRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IClassHasSpellRepository _classHasSpellRepo;
    public ClassRepository(ApplicationDbContext context, IClassHasSpellRepository classHasSpellRepo)
    {
        _context = context;
        _classHasSpellRepo = classHasSpellRepo;
    }

    public async Task<Class?> AddClassAsync(AddClass classDto)
    {
        var classModel = classDto.ToClassFromCreate();
        var classExist = await _context.Class.FirstOrDefaultAsync(c => c.Name == classDto.Name);
        if (classExist != null)
            return null;
        await _context.Class.AddAsync(classModel);
        await _context.SaveChangesAsync();
        return classModel;
    }

    public async Task<List<Class>> GetAllAsync()
    {
        return await _context.Class.ToListAsync();
    }

    public async Task<Class?> GetByIdAsync(int id)
    {
        var classModel = await _context.Class.FirstOrDefaultAsync(c => c.Id == id);
        if (classModel == null)
            return null;
        return classModel;
    }

    public async Task<List<Spell>?> GetClassSpellsAsync(int classId)
    {
        var classModel = await _context.Class.FirstOrDefaultAsync(c => c.Id == classId);
        if (classModel == null)
            return null;
        var spells = await _classHasSpellRepo.GetClassSpellsAsync(classModel.Id);
        return spells.Select(s => s.Spell ?? new Spell { }).ToList();
    }
}