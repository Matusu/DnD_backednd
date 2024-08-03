using webapi.Dtos;
using webapi.Models;

namespace webapi.Repository;

public interface IRaceRepository
{
    Task<List<Race>> GetAllAsync();
    Task<Race?> GetByIdAsync(int id);
    Task<Race?> AddRaceAsync(AddRace raceDto);
}