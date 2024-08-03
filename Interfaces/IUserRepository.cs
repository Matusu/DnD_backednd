using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User?> CreateAsync(RegisterUserDto userDto);
    Task<User?> UpdateAsync(int id, UserDto userDto);
    Task<User?> DeleteAsync(int id);
    Task<bool> UserExistsAsync(int id);
}