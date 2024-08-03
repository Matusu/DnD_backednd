using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;
public class FeatureRepository : IFeatureRepository
{
    private readonly ApplicationDbContext _context;
    public FeatureRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Feature?> CreateFeatureAsync(AddFeature featureDto)
    {
        var featureModel = featureDto.ToFeatureFromCreate();
        var featureExist = await _context.Feature.FirstOrDefaultAsync(f => f.Name == featureDto.Name);
        if (featureExist != null)
            return null;
        await _context.Feature.AddAsync(featureModel);
        await _context.SaveChangesAsync();
        return featureModel;
    }

    public async Task<Feature?> GetByIdAsync(int id)
    {
        var feature = await _context.Feature.FirstOrDefaultAsync(f => f.Id == id);
        if (feature == null)
            return null;
        return feature;
    }

    public async Task<List<Feature>> GettAllAsync()
    {
        return await _context.Feature.ToListAsync();
    }
}