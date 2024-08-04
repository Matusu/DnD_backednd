namespace webapi.Models;

public class Campain
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? UserId { get; set; }
    public appUser? User { get; set; }
    public List<Character>? Characters { get; set; }
}