using VlakRegion.Model.Exceptions;
using VlakRegion.Model.Segments;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Line
{
    public class Line
    {
        private readonly Segment _segmentFrom;

        public string Name { get; private set; }

        public RailwayStation From { get; private set; }

        public  RailwayStation To { get; private set; }

        public Line(RailwayStation fromObj, RailwayStation toObj, string name, float distance)
        {
            Name = name;
            From = fromObj;
            To = toObj;

            _segmentFrom = new Segment(From, To, distance);
        }

        public void Insert(RailwayStation fromObject, TrackObject newObject, float distanceFrom)
        {
            if (fromObject == From) {
                _segmentFrom.Insert(From, newObject, distanceFrom);
                return;
            }

            if (fromObject != To) {
                throw new VrException("Railway station isn't part of this Line.");
            }

            Segment segment = FindSegmentEndsWith(To);
            if (segment == null) {
                throw new VrException("Railway station isn't part of this Line.");
            }

            segment.Insert(To, newObject, distanceFrom);
        }

        private Segment FindSegmentEndsWith(TrackObject toObject)
        {
            Segment segment = _segmentFrom;
            while (segment != null && segment.To != toObject)
            {
                segment = segment.Next;
            }
            return segment;
        }
    }
}
