using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Dtos;
using webapi.Interfaces;
using webapi.Mappers;

namespace webapi.Controllers;
[Route("webapi/[Controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    public UserController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = await _userRepo.GetAllAsync();
        var userDto = user.Select(s => s.ToUserDto());
        return Ok(userDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user.ToUserDto());
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto userDto)
    {
        var userModel = await _userRepo.CreateAsync(userDto);
        if (userModel == null)
        {
            return BadRequest("User existuje");
        }
        return CreatedAtAction(nameof(GetById), new { id = userModel.Id }, userModel.ToUserDto());
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserDto userDto)
    {
        var userModel = await _userRepo.UpdateAsync(id, userDto);
        if (userModel == null)
        {
            return NotFound();
        }
        return Ok(userModel.ToUserDto());
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = await _userRepo.DeleteAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return NoContent();
    }
}