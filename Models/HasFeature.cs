namespace webapi.Models;

public class HasFeature
{
    public int Id { get; set; }
    public int FeatureId { get; set; }
    public Feature? Feature { get; set; }
    public int ClassId { get; set; }
    public Class? Class { get; set; }
    public int RaceId { get; set; }
    public Race? Race { get; set; }
}