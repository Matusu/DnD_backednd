using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class CharacterRepository : ICharacterRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IHasFeatureRepository _hasFeatureRepo;
    private readonly ICharacterHasSpellRepository _characterHasSpellRepo;

    public CharacterRepository(ApplicationDbContext context, IHasFeatureRepository hasFeatureRepo, ICharacterHasSpellRepository characterHasSpellRepo)
    {
        _context = context;
        _hasFeatureRepo = hasFeatureRepo;
        _characterHasSpellRepo = characterHasSpellRepo;
    }

    public async Task<Character?> CreateCharacterAsync(AddCharacterDto addCharacterDto)
    {
        var character = addCharacterDto.ToCharacterFromCreate();
        var characterExist = await _context.Character.FirstOrDefaultAsync(c => c.Name == character.Name);
        if (characterExist != null)
            return null;
        await _context.Character.AddAsync(character);
        await _context.SaveChangesAsync();
        return character;

    }

    public async Task<List<Character>> GetAllAsync()
    {
        return await _context.Character.ToListAsync();
    }

    public async Task<List<Feature>?> GetCharacterFeatureAsync(int id)
    {
        var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            return null;
        var features = await _hasFeatureRepo.GetCharacterFeaturesAsync(character.ClassId, character.RaceId);
        return features.Select(f => f.Feature ?? new Feature { }).ToList();
    }

    public async Task<List<Spell>?> GetCharacterSpellAsync(int id)
    {
        var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            return null;
        var spells = await _characterHasSpellRepo.GetCharacterSpellsAsync(character.Id);
        return spells.Select(c => c.Spell ?? new Spell { }).ToList();
    }

    public async Task<List<Spell>?> GetPreparedCharacterSpellAsync(int id)
    {
        var character = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
            return null;
        var spells = await _characterHasSpellRepo.GetPreparedCharacterSpellAsync(character.Id);
        return spells.Select(c => c.Spell ?? new Spell { }).ToList();
    }
}