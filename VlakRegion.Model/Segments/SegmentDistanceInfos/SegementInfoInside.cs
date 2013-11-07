using System;
using VlakRegion.Model.Common;
using VlakRegion.Model.Exceptions;
using VlakRegion.Model.Segments.FirstLastAccessors;
using VlakRegion.Model.Segments.Iterators;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.SegmentDistanceInfos
{
    public class SegementInfoInside : ISegementInfoMiddle
    {
        private readonly Segment _segment;
        private readonly float _distanceFull;
        private readonly Direction _direction;

        public SegementInfoInside(ISegmentIterator iterator, Segment segment, float distanceSum)
        {
            _segment = segment;
            _distanceFull = distanceSum;
            _direction = iterator.Direction;
        }

        public virtual bool IsEmpty
        {
            get { return false; }
        }

        public Segment Segment
        {
            get { return _segment; }
        }

        public Segment Insert(TrackObject insertedOject, float distanceFromBegining)
        {
            Segment insertedSegment = new Segment();
            IFirstLastAccessor insertedFLAccessor = FirstLastAccessorFactory.Create(_direction, insertedSegment);
            IFirstLastAccessor segmentFLAccessor = FirstLastAccessorFactory.Create(_direction, _segment);

            insertedFLAccessor.FirstObject = segmentFLAccessor.FirstObject;
            insertedFLAccessor.LastObject = insertedOject;

            segmentFLAccessor.FirstObject = insertedOject;

            Segment prevSegment = segmentFLAccessor.PrevSegment;

            insertedFLAccessor.NextSegment = _segment;
            insertedFLAccessor.PrevSegment = prevSegment;
            segmentFLAccessor.PrevSegment = insertedSegment;


            if (prevSegment != null)
            {
                IFirstLastAccessor prevSegmentFLAccessor = FirstLastAccessorFactory.Create(_direction, prevSegment);
                prevSegmentFLAccessor.NextSegment = insertedSegment;
            }

            float distance = distanceFromBegining - _distanceFull;
            if (distance > 0.0)
            {
                throw new VrException(String.Format("Longer distance '{0}' can't be appended, only appended!", distance));
            }

            float insertedSegmentDistance = _segment.Distance + distance;
            insertedSegment.Distance = insertedSegmentDistance;
            _segment.Distance = _segment.Distance - insertedSegmentDistance;

            return insertedSegment;

        }
    }
}