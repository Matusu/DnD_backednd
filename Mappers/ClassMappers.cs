using webapi.Dtos;
using webapi.Models;

namespace webapi.Mappers;

public static class ClassMappers
{
    public static ClassDto ToClassDto(this Class classModel)
    {
        return new ClassDto
        {
            Id = classModel.Id,
            Name = classModel.Name,
        };
    }
}