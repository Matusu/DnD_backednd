using System.ComponentModel.DataAnnotations;

namespace webapi.Dtos;

public class AddSpellToCharacterDto
{
    [Required]
    public int SpellId { get; set; }
    [Required]
    public int CharacterId { get; set; }
    [Required]
    public bool Prepared { get; set; }
}