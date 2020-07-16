namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point(double lat, double log)
        {
            Latitude = lat;
            Longitude = log;
        }
    }

    
}