using System;
using VlakRegion.Model.Common;
using VlakRegion.Model.Exceptions;
using VlakRegion.Model.Segments.FirstLastAccessors;
using VlakRegion.Model.Segments.Iterators;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.SegmentDistanceInfos
{
    public class SegementInfoAtEnd : ISegementInfoAtAnd
    {
        private readonly Segment _segment;
        private readonly float _distanceFull;
        private readonly Direction _direction;

        public SegementInfoAtEnd(ISegmentIterator iterator, Segment segment, float distanceSum)
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

        public Segment Append(TrackObject appendedOject, float distanceFromBegining)
        {
            Segment appendedSegment = new Segment();
            IFirstLastAccessor appendedFLAccessor = FirstLastAccessorFactory.Create(_direction, appendedSegment);
            IFirstLastAccessor segmentFLAccessor = FirstLastAccessorFactory.Create(_direction, _segment);

            appendedFLAccessor.LastObject = appendedOject;
            appendedFLAccessor.FirstObject = segmentFLAccessor.LastObject;

            appendedFLAccessor.PrevSegment = _segment;
            segmentFLAccessor.NextSegment = appendedSegment;

            float appendedSegmentDistance = distanceFromBegining - _distanceFull;
            if (appendedSegmentDistance <= 0.0) {
                throw new VrException(String.Format("Shorter distance '{0}' can't be appended, only inserted!", appendedSegmentDistance));
            }

            appendedSegment.Distance = appendedSegmentDistance;

            return appendedSegment;
        }
    }
}