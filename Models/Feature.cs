namespace webapi.Models;

public class Feature
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<HasFeature>? HasFeatures { get; set; }
}