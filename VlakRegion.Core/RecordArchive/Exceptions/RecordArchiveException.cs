using System;
using System.Runtime.Serialization;

namespace VlakRegion.Core.RecordArchive.Exceptions
{
    public class RecordArchiveException : Exception
    {
        public RecordArchiveException()
        {
        }

        public RecordArchiveException(string message) : base(message)
        {
        }

        public RecordArchiveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecordArchiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
