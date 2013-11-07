using System.Collections.Generic;
using VlakRegion.Model.Common;

namespace VlakRegion.Model.TrackObjects.Signs
{
    public class Sign : TrackObject
    {
        private readonly List<Sign> _additionalSigns = new List<Sign>(0);
        public Direction Direction { get; set; }

        public IList<Sign> AdditionalSigns
        {
            get { return _additionalSigns; }
        }
    }
}
