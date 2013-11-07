namespace VlakRegion.Model.Common
{
    public class CoortinateEmpty : Coordinate
    {
        public new float Longitude
        {
            get { return 0.0f; }
        }

        public new float Latitude
        {
            get { return 0.0f; }
        }

        public new float Altitude
        {
            get { return 0.0f; }
        }
    }
}
