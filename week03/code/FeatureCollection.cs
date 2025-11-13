public class FeatureCollection
{
    public Feature[] Features { get; set; }
}

public class Feature
{
    public FeatureProperty Properties { get; set; }
}

public class FeatureProperty
{
    public string Place { get; set; }
    public float Mag { get; set; }
}