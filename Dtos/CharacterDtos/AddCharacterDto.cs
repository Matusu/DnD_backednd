using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddCharacterDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    public int RaceId { get; set; }
    [Required]
    public int ClassId { get; set; }
    [Required]
    public int CampainId { get; set; }
    [Required]
    public string? UserId { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(2)]
    public int Streangth { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(2)]
    public int Dexterity { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(2)]
    public int Intelligence { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(2)]
    public int Wisdom { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(2)]
    public int Constitution { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(2)]
    public int Charisma { get; set; }
}