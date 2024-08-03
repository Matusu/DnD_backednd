using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class SpellRepository : ISpellRepository
{
    private readonly ApplicationDbContext _context;
    public SpellRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Spell?> AddSpellAsync(AddSpellDto addSpellDto)
    {
        var spellModel = addSpellDto.ToSpellFromCreate();
        var spellExist = await _context.Spell.FirstOrDefaultAsync(s => s.Name == spellModel.Name);
        if (spellExist != null)
            return null;
        await _context.Spell.AddAsync(spellModel);
        await _context.SaveChangesAsync();
        return spellModel;
    }

    public async Task<List<Spell>> GetAllAsync()
    {
        return await _context.Spell.ToListAsync();
    }
}