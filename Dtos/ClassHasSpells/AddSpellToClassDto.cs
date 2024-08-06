using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddSpellToClassDto
{
    [Required]
    public int SpellId { get; set; }
    [Required]
    public int ClassId { get; set; }

}