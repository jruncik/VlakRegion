using System.Diagnostics;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.FirstLastAccessors
{
    public class FirstLastAccessorEmpty : IFirstLastAccessor
    {
        public static readonly IFirstLastAccessor Empty = new FirstLastAccessorEmpty();

        public TrackObject FirstObject
        {
            get { return null; }
            set { Debug.Assert(false, "Empty FirstLast accessor cant set anything!"); }
        }

        public TrackObject LastObject
        {
            get { return null; }
            set { Debug.Assert(false, "Empty FirstLast accessor cant set anything!"); }
        }

        public Segment PrevSegment
        {
            get { return null; }
            set { Debug.Assert(false, "Empty FirstLast accessor cant set anything!");  }
        }

        public Segment NextSegment
        {
            get { return null; }
            set { Debug.Assert(false, "Empty FirstLast accessor cant set anything!"); }
        }
    }
}