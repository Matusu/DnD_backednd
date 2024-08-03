
namespace webapi.Models;

public class Class
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<ClassHasSpell>? ClassHasSpells { get; }
    public List<HasFeature>? HasFeatures { get; set; }
    public List<Character>? Characters { get; set; }
}