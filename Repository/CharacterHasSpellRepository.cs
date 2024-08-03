using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class CharacterHasSpellRepository : ICharacterHasSpellRepository
{
    private readonly ApplicationDbContext _context;
    public CharacterHasSpellRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<CharacterHasSpell> AddSpellToCharacterAsync(AddSpellToCharacterDto addSpellToCharacterDto)
    {
        var characterHasSpellModel = addSpellToCharacterDto.ToCharacterHasSpell();
        await _context.CharacterHasSpells.AddAsync(characterHasSpellModel);
        await _context.SaveChangesAsync();
        return characterHasSpellModel;

    }
    public async Task<List<CharacterHasSpell>> GetCharacterSpellsAsync(int id)
    {
        return await _context.CharacterHasSpells.Where(c => c.CharacterId == id).Include(c => c.Spell).ToListAsync();
    }

    public async Task<List<CharacterHasSpell>> GetAllAsync()
    {
        return await _context.CharacterHasSpells.ToListAsync();
    }

    public async Task<List<CharacterHasSpell>> GetPreparedCharacterSpellAsync(int id)
    {
        return await _context.CharacterHasSpells.Where(c => c.CharacterId == id && c.Prepared).Include(c => c.Spell).ToListAsync();
    }
}