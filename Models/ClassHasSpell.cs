namespace webapi.Models;

public class ClassHasSpell
{
    public int Id { get; set; }
    public int SpellId { get; set; }
    public Spell? Spell { get; set; }
    public int ClassId { get; set; }
    public Class? Class { get; set; }

}