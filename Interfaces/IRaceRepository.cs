using webapi.Models;

namespace webapi.Repository;

public interface IRaceRepository
{
    Task<List<Race>> GetAllAsync();
}