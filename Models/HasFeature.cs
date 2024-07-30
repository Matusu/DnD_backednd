namespace webapi.Models;

public class HasFeature
{
    public int Id { get; set; }
    public int FeatureId { get; set; }
    public Feature? Feature { get; set; }
    public bool ClassFeature { get; set; }
    public bool RaceFeature { get; set; }
}