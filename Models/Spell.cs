namespace webapi.Models;

public class Spell
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ClassHasSpell>? ClassHasSpells { get; }
    public List<CharacterHasSpell>? CharacterHasSpells { get; set; }
}