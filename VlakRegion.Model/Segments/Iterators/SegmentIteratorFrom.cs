using System.Diagnostics.Contracts;
using VlakRegion.Model.Common;

namespace VlakRegion.Model.Segments.Iterators
{
    public class SegmentIteratorFrom : ISegmentIterator
    {
        private readonly Segment _firstSegment;

        public SegmentIteratorFrom(Segment firstSegment)
        {
            Contract.Ensures(firstSegment != null);

            _firstSegment = firstSegment;
            Reset();
        }

        public Segment Current { get; private set; }

        public bool MoveNext()
        {
            if (Current.Next == null) {
                return false;
            }

            Current = Current.Next;
            return true;
        }

        public void Reset()
        {
            Current = _firstSegment;
        }

        public Direction Direction
        {
            get { return Direction.From; }
        }
    }
}
