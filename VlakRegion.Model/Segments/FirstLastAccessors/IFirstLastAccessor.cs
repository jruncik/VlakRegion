using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.FirstLastAccessors
{
    public interface IFirstLastAccessor
    {
        TrackObject FirstObject { get; set; }
        TrackObject LastObject { get; set; }

        Segment PrevSegment { get; set; }
        Segment NextSegment { get; set; }
    }
}
