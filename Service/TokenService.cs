using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config, ApplicationDbContext context)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"] ?? ""));
        _context = context;
    }
    public string CreateToken(appUser user)
    {
        var claims = new List<Claim>{
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName ?? "")
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public async Task<ResponsDto> GetUserByIdAsync(string id)
    {
        var user = await _context.Users.FirstAsync(x => x.Id == id);
        return new ResponsDto { UserName = user.UserName };
    }

    public void SetTokenInsideCookie(string token, HttpContext context)
    {
        context.Response.Cookies.Append("accesToken", token,
        new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddMinutes(5),
            HttpOnly = true,
            IsEssential = true,
            Secure = true,
            SameSite = SameSiteMode.None
        });
    }
}