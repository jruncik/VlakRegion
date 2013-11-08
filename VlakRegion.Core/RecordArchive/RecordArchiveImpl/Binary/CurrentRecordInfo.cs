using System;
using VlakRegion.Core.RecordArchive.Exceptions;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl.Binary
{
    internal struct CurrentRecordInfo
    {
        public readonly RecordDescriptor RecordDescriptor;
        public readonly Int32 RecordSizePosition;

        public CurrentRecordInfo(RecordDescriptor recordDescriptor, Int64 recordSizePosition)
        {
            RecordDescriptor = recordDescriptor;
            RecordSizePosition = (Int32)recordSizePosition;

            if (RecordSizePosition != recordSizePosition)
            {
                throw new RecordArchiveException("Record size overflow detected");
            }
        }
    }
}