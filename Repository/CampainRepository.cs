using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class CampainRepository : ICampainRepository
{
    private readonly ApplicationDbContext _context;
    public CampainRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Campain> CreateAsync(Campain campain)
    {
        await _context.Campain.AddAsync(campain);
        await _context.SaveChangesAsync();
        return campain;
    }

    public async Task<List<Campain>> GetAllAsync()
    {
        return await _context.Campain.Include(x => x.User).ToListAsync();
    }

    public async Task<Campain?> GetByIdAsync(int id)
    {
        var campainModel = await _context.Campain.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        return campainModel;
    }
}