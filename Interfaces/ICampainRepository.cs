using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface ICampainRepository
{
    Task<List<Campain>> GetAllAsync();
    Task<Campain?> GetByIdAsync(int id);
    Task<Campain> CreateAsync(Campain campain);
}