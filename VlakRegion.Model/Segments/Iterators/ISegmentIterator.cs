using VlakRegion.Model.Common;

namespace VlakRegion.Model.Segments.Iterators
{
    public interface ISegmentIterator
    {
        Segment Current { get; }
        Direction Direction { get; }
        bool MoveNext();
        void Reset();
    }
}
