namespace VlakRegion.Model.Common
{
    public class Coordinate
    {
        public static readonly Coordinate Empty = new CoortinateEmpty();

        public Coordinate(float altitude)
        {
            Altitude = altitude;
        }

        public Coordinate(float longitude, float latitude, float altitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Altitude = altitude;
        }

        protected Coordinate()
        {
        }

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public float Altitude { get; set; }
    }
}
