namespace webapi.Dtos;

public class AddSpellToCharacterDto
{
    public int SpellId { get; set; }
    public int CharacterId { get; set; }
    public bool Prepared { get; set; }
}