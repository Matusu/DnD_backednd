
using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class CreateCampainDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string? Name { get; set; }
}