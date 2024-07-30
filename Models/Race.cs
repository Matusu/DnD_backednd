namespace webapi.Models;

public class Race
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<HasFeature>? HasFeature { get; set; }

}