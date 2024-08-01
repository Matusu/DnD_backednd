using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repository;

class CharacterRepository : ICharacterRepository
{
    private readonly ApplicationDbContext _context;
    public CharacterRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Character>> GetAllAsync()
    {
        return await _context.Character.ToListAsync();
    }

    public async Task<Character?> GetByIdAsync(int id)
    {
        var characterModel = await _context.Character.FirstOrDefaultAsync(x => x.Id == id);
        if (characterModel == null)
        {
            return null;
        }
        return characterModel;
    }
}