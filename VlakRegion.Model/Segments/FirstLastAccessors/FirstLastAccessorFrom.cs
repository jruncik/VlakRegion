using System.Diagnostics.Contracts;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.FirstLastAccessors
{
    public class FirstLastAccessorFrom : IFirstLastAccessor
    {
        private readonly Segment _segment;

        public FirstLastAccessorFrom(Segment segment)
        {
            Contract.Ensures(segment != null);
            _segment = segment;
        }

        public TrackObject FirstObject
        {
            get { return _segment.From; }
            set { _segment.From = value; }
        }

        public TrackObject LastObject
        {
            get { return _segment.To; }
            set { _segment.To = value; }
        }

        public Segment PrevSegment
        {
            get { return _segment.Prev; }
            set { _segment.Prev = value; }
        }

        public Segment NextSegment
        {
            get { return _segment.Next; }
            set { _segment.Next = value; }
        }
    }
}
