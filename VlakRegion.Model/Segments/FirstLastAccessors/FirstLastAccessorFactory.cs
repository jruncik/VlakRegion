using VlakRegion.Model.Common;

namespace VlakRegion.Model.Segments.FirstLastAccessors
{
    public static class FirstLastAccessorFactory
    {
        public static IFirstLastAccessor Create(Direction direction, Segment segment)
        {
            switch (direction) {
                case Direction.From: {
                    return new FirstLastAccessorFrom(segment);
                } // break;

                case Direction.To: {
                    return new FirstLastAccessorTo(segment);
                } // break;
            }

            return FirstLastAccessorEmpty.Empty;
        }
    }
}
