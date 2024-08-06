using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public class HasFeatureDto
{
    [Required]
    public int FeatureId { get; set; }
    [Required]
    public int ClassId { get; set; }
    [Required]
    public int RaceId { get; set; }
}