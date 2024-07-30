namespace webapi.Models;

public class Spell
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ClassHasSpells>? ClassHasSpells { get; }
    public List<CharacterHasSpells>? CharacterHasSpells { get; set; }
}