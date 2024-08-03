using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class ClassMappers
{
    public static ClassDto ToClassDto(this Class classModel)
    {
        return new ClassDto
        {
            Name = classModel.Name,
        };
    }
    public static Class ToClassFromCreate(this AddClass addClass)
    {
        return new Class
        {
            Name = addClass.Name
        };
    }
}