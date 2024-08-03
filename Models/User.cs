
namespace webapi.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public List<Campain>? Campains { get; set; }
    public List<Character>? Characters { get; set; }
}