using System.Diagnostics.Contracts;
using VlakRegion.Model.Common;

namespace VlakRegion.Model.Segments.Iterators
{
    public class SegmentIteratorTo : ISegmentIterator
    {
        private readonly Segment _firstSegment;

        public SegmentIteratorTo(Segment firstSegment)
        {
            Contract.Ensures(firstSegment != null);

            _firstSegment = firstSegment;
            Reset();
        }

        public Segment Current { get; private set; }

        public bool MoveNext()
        {
            if (Current.Prev == null) {
                return false;
            }

            Current = Current.Prev;
            return true;
        }

        public void Reset()
        {
            Current = _firstSegment;
        }

        public Direction Direction
        {
            get { return Direction.To; }
        }
    }
}
