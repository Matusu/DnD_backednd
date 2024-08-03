namespace webapi.Models;

public class Race
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<HasFeature>? HasFeatures { get; set; }
    public List<Character>? Characters { get; set; }

}