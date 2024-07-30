namespace webapi.Models;

public class Campain
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public User? User { get; set; }
}