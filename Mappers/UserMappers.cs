using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

static public class UserMappers
{
    static public UserDto ToUserDto(this User userModel)
    {
        return new UserDto
        {
            Username = userModel.Username,
            Password = userModel.Password,
        };
    }
    public static User ToUserFromCreateDto(this RegisterUserDto userDto)
    {
        return new User
        {
            Username = userDto.Username,
            Password = userDto.Password,
        };
    }
}