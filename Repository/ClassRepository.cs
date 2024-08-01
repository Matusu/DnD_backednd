using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Repository;

public class ClassRepository : IClassRepository
{
    private readonly ApplicationDbContext _context;
    public ClassRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Class>> GetAllAsync()
    {
        return await _context.Class.ToListAsync();
    }
}