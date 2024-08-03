namespace webapi.Models;

public class CharacterHasSpell
{
    public int Id { get; set; }
    public int SpellId { get; set; }
    public Spell? Spell { get; set; }
    public int CharacterId { get; set; }
    public Character? Character { get; set; }
    public bool Prepared { get; set; }
}