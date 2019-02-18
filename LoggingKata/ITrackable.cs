namespace LoggingKata
{
    /// <summary>
    /// allows an object to be treated as a location on a map
    /// </summary>
    public interface ITrackable
    {
        string Name { get; set; }
        Point Location { get; set; }
    }
}