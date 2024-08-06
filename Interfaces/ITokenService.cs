using webapi.Dtos;
using webapi.Models;

namespace webapi.Interfaces;

public interface ITokenService
{
    string CreateToken(appUser user);
    void SetTokenInsideCookie(string token, HttpContext context);
    Task<ResponsDto> GetUserByIdAsync(string id);
}