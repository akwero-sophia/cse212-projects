// SOLUTION Problem 5 - JSON Deserialization Classes

/// <summary>
/// Root object for the USGS earthquake GeoJSON data
/// </summary>
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

/// <summary>
/// Represents a single earthquake feature
/// </summary>
public class Feature
{
    public Properties Properties { get; set; }
}

/// <summary>
/// Contains the properties of an earthquake including place and magnitude
/// </summary>
public class Properties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}