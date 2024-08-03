namespace webapi.Dtos;

public class CharacterHasSpellDto
{
    public int SpellId { get; set; }
    public int CharacterId { get; set; }
    public bool Prepared { get; set; }
}