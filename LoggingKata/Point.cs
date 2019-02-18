namespace LoggingKata
{
    /// <summary>
    /// a coordinate point containing two doubles
    /// </summary>
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double x, double y)
        {
            this.Latitude = x;
            this.Longitude = y;
        }
    }
}