using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddClass
{
    [Required]
    public string? Name { get; set; }
}