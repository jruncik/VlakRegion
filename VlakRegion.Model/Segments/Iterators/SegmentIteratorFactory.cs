using System;
using System.Diagnostics.Contracts;
using VlakRegion.Model.Common;
using VlakRegion.Model.Exceptions;

namespace VlakRegion.Model.Segments.Iterators
{
    public static class SegmentIteratorFactory
    {
        public static ISegmentIterator Create(Direction direction, Segment segment)
        {
            Contract.Ensures(segment != null);

            switch (direction) {
                case Direction.From: {
                    return new SegmentIteratorFrom(segment);
                } // break;

                case Direction.To: {
                    return new SegmentIteratorTo(segment);
                } // break;
            }

            throw new VrException(String.Format("Can't create iterator for direction '{0}'.", direction));
        }
    }
}
