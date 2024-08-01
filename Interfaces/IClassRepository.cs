using webapi.Models;

namespace webapi.Interfaces;

public interface IClassRepository
{
    Task<List<Class>> GetAllAsync();
}