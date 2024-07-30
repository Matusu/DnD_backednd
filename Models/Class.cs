
namespace webapi.Models;

public class Class
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int SpellId { get; set; }
    public Spell? Spell { get; set; }
    public List<ClassHasSpells>? ClassHasSpells { get; }
    public List<HasFeature>? HasFeature { get; set; }
}