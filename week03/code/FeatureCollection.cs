public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public string type { get; set; }
    public List<Feature> features { get; set; }



}

public class Feature
{
    public string type { get; set; }
    public Property properties { get; set; }

}

public class Property
{
    public double mag { get; set; }
    public string place { get; set; }
    
    public long time { get; set; }
}