using System;
using System.Diagnostics;
using System.Text;
using VlakRegion.Model.Common;
using VlakRegion.Model.Exceptions;
using VlakRegion.Model.Segments.Iterators;
using VlakRegion.Model.Segments.SegmentDistanceInfos;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments
{
    public class Segment
    {
        public Segment()
        {
        }

        public Segment(TrackObject from, TrackObject to, float distance)
        {
            From = from;
            To = to;
            Distance = distance;
        }

        public Segment Next { get; set; }
        public Segment Prev { get; set; }

        public TrackObject From { get; set; }
        public TrackObject To { get; set; }

        public float Distance { get; set; }

        public Segment Insert(TrackObject fromObject, TrackObject newObject, float distanceFrom)
        {
            ISegementInfo segmentDistInfo = TryGetSegmantAtDistance(fromObject, distanceFrom);

            if (segmentDistInfo is ISegementInfoAtAnd)
            {
                return ((ISegementInfoAtAnd)segmentDistInfo).Append(newObject, distanceFrom);
            }
            return ((ISegementInfoMiddle)segmentDistInfo).Insert(newObject, distanceFrom);
        }

        public Segment GetSegmantAtDistance(TrackObject fromObject, float distance)
        {
            ISegementInfo segmentInfo = TryGetSegmantAtDistance(fromObject, distance);

            if (segmentInfo is ISegementInfoAtAnd)
            {
                throw new VrException("Segment is small.");
            }
            return segmentInfo.Segment;
        }

        public ISegementInfo TryGetSegmantAtDistance(TrackObject fromObject, float distance)
        {
            ISegmentIterator iterator = CreateSegmentIterator(fromObject);

            float distanceSum = iterator.Current.Distance;

            while (distanceSum < distance && iterator.MoveNext()) {
                distanceSum += iterator.Current.Distance;
            }

            if (distanceSum < distance) {
                return new SegementInfoAtEnd(iterator, iterator.Current, distanceSum);
            }

            return new SegementInfoInside(iterator, iterator.Current, distanceSum);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("--------------------------").AppendLine();
            result.Append("From:\t").Append(From.ToString()).AppendLine();
            result.Append("Dist:\t").Append(Distance.ToString()).AppendLine();
            result.Append("To:\t\t").Append(To.ToString());

            return result.ToString();
        }

        [Conditional("DEBUG")]
        public void DebugPrint()
        {
            Segment current = this;

            while (current != null)
            {
                Debug.WriteLine(current.ToString());
                current = current.Next;
            }

            Debug.WriteLine("--------------------------");
        }

        protected ISegmentIterator CreateSegmentIterator(TrackObject from)
        {
            Direction direction = GetDirection(from);
            return CreateSegmentIterator(direction);
        }

        protected ISegmentIterator CreateSegmentIterator(Direction direction)
        {
            return SegmentIteratorFactory.Create(direction, this);
        }

        protected Direction GetDirection(TrackObject trackObj)
        {
            if (trackObj == From) {
                return Direction.From;
            }

            if (trackObj == To) {
                return Direction.To;
            }

            throw new VrException(String.Format("TrackObject '{0}' isn't part of this Segment '{1}' - '{2}'", trackObj.Name, From.Name, To.Name));
        }
    }
}
