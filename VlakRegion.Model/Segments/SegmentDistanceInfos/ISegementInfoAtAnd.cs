using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.SegmentDistanceInfos
{
    internal interface ISegementInfoAtAnd : ISegementInfo
    {
        Segment Append(TrackObject appendedOject, float distanceFromBegining);
    }
}