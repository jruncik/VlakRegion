using System;

namespace VlakRegion.Model.Exceptions
{
    [Serializable]
    public class VrException : Exception
    {
        public VrException(string message) : base(message)
        {
        }
    }
}
