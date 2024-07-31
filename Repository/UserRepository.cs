using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;
using webapi.Models;

namespace webapi.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> CreateAsync(RegisterUserDto userDto)
    {
        var userModel = userDto.ToUserFromCreateDto();
        var doesExist = await _context.User.FirstOrDefaultAsync(x => x.Username == userModel.Username);
        if (doesExist != null)
        {
            return null;
        }
        await _context.User.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return userModel;
    }

    public async Task<User?> DeleteAsync(int id)
    {
        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (userModel == null)
        {
            return userModel;
        }
        _context.User.Remove(userModel);
        await _context.SaveChangesAsync();
        return userModel;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        return userModel;
    }

    public async Task<User?> UpdateAsync(int id, UserDto userDto)
    {
        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (userModel == null)
        {
            return userModel;
        }
        userModel.Username = userDto.Username;
        userModel.Password = userDto.Password;
        await _context.SaveChangesAsync();
        return userModel;
    }
}