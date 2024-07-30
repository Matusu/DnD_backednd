using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Mappers;

namespace webapi.Controllers;
[Route("webapi/User")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _context.User.ToListAsync();
        var userDto = user.Select(s => s.ToUserDto());
        return Ok(userDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user.ToUserDto());
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto userDto)
    {
        var userModel = userDto.ToUserFromCreateDto();
        var doesExist = await _context.User.FirstOrDefaultAsync(x => x.Username == userModel.Username);
        if (doesExist != null)
        {
            return BadRequest();
        }
        await _context.User.AddAsync(userModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDto userDto)
    {
        var userModel = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (userModel == null)
        {
            return NotFound();
        }
        userModel.Username = userDto.Username;
        userModel.Password = userDto.Password;
        await _context.SaveChangesAsync();
        return Ok(userModel.ToUserDto());
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}