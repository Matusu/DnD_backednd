
using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddFeature
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}