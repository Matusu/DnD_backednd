using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class HasFeatureRepository : IHasFeatureRepository
{
    private readonly ApplicationDbContext _context;
    public HasFeatureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HasFeature> AddFeatureLinkAsync(HasFeatureDto hasFeatureDto)
    {
        var hasFeature = hasFeatureDto.ToHasFeatureModel();
        await _context.HasFeature.AddAsync(hasFeature);
        await _context.SaveChangesAsync();
        return hasFeature;

    }

    public async Task<List<HasFeature>> GetCharacterFeaturesAsync(int classId, int raceId)
    {
        return await _context.HasFeature.Where(f => f.ClassId == classId || f.RaceId == raceId).Include(f => f.Feature).ToListAsync();
    }
}