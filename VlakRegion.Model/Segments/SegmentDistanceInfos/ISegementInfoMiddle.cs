using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Segments.SegmentDistanceInfos
{
    internal interface ISegementInfoMiddle : ISegementInfo
    {
        Segment Insert(TrackObject insertedOject, float distanceFromBegining);
    }
}