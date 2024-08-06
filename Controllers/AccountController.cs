using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Migrations;
using webapi.Models;

namespace webapi.Controllers;
[ApiController]
[Route("webapi/[Controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<appUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<appUser> _signingManager;
    public AccountController(UserManager<appUser> userManager, ITokenService tokenService, SignInManager<appUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signingManager = signInManager;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName);
        if (user == null)
            return Unauthorized("Invalid username or password");
        var result = await _signingManager.CheckPasswordSignInAsync(user, loginDto.Password ?? "", false);
        if (!result.Succeeded)
            return Unauthorized("Invalid password or password");
        _tokenService.SetTokenInsideCookie(_tokenService.CreateToken(user), HttpContext);
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = new appUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };
            var createUser = await _userManager.CreateAsync(user, registerDto.Password ?? "");
            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    _tokenService.SetTokenInsideCookie(_tokenService.CreateToken(user), HttpContext);
                    return Ok();
                }
                else
                    return StatusCode(500, roleResult.Errors);
            }
            else
                return StatusCode(500, createUser.Errors);
        }

        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }
}