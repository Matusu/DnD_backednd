namespace webapi.Dtos;

public class CharacterDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int RaceId { get; set; }
    public int ClassId { get; set; }
    public int CampainId { get; set; }
    public int UserId { get; set; }
    public int Streangth { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Constitution { get; set; }
    public int Charisma { get; set; }
}