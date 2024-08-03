namespace webapi.Models;


public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int RaceId { get; set; }
    public Race? Race { get; set; }
    public int ClassId { get; set; }
    public Class? Class { get; set; }
    public int CampainId { get; set; }
    public Campain? Campain { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int Streangth { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Constitution { get; set; }
    public int Charisma { get; set; }
    public List<CharacterHasSpell>? CharacterHasSpells { get; set; }

}