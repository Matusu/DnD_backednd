using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddRace
{
    [Required]
    public string? Name { get; set; }
}