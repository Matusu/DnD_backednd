using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;

namespace webapi.Repository;

public class RaceRepository : IRaceRepository
{
    private readonly ApplicationDbContext _context;
    public RaceRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Race>> GetAllAsync()
    {
        return await _context.Race.ToListAsync();
    }
}