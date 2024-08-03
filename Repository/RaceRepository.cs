using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class RaceRepository : IRaceRepository
{
    private readonly ApplicationDbContext _context;
    public RaceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Race?> AddRaceAsync(AddRace raceDto)
    {
        var raceModel = raceDto.ToRaceFromCreate();
        var raceExist = await _context.Race.FirstOrDefaultAsync(r => r.Name == raceModel.Name);
        if (raceExist != null)
            return null;
        await _context.Race.AddAsync(raceModel);
        await _context.SaveChangesAsync();
        return raceModel;
    }

    public async Task<List<Race>> GetAllAsync()
    {
        return await _context.Race.ToListAsync();
    }

    public async Task<Race?> GetByIdAsync(int id)
    {
        var race = await _context.Race.FirstOrDefaultAsync(r => r.Id == id);
        if (race == null)
            return null;
        return race;
    }
}