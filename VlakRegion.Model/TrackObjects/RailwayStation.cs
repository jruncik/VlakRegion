using System;

namespace VlakRegion.Model.TrackObjects
{
    public class RailwayStation : TrackObject
    {
        public RailwayStation() : this(String.Empty)
        {
        }

        public RailwayStation(String name)
        {
            Name = name;
        }
    }
}
