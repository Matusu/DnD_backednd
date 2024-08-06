using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddSpellDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}