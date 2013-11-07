using System;
using VlakRegion.Model.Common;

namespace VlakRegion.Model.TrackObjects
{
    public class TrackObject
    {
        public string Name { get; set; }
        public Coordinate Coordinate { get; set; }

        public override string ToString()
        {
            return String.Format("'{0}' - '{1}'", GetType().Name, Name);
        }
    }

    public sealed class TrackObjectEmpty : TrackObject
    {
        public new string Name
        {
            get { return String.Empty; }
        }

        public new Coordinate Coordinate { get; set; }
    }
}
