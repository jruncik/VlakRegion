using System;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl.Binary
{
    internal class RecordArchiveReaderBinary : RecordArchiveReader
    {
        public RecordArchiveReaderBinary(Stream stream) : base(stream, new BinaryReaderImpl(stream))
        {
        }

        public override RecordDescriptor NewRecord()
        {
            throw new NotImplementedException();
        }

        public override void EndRecord()
        {
            throw new NotImplementedException();
        }

        public override void SkipCurrentRecord()
        {
            throw new NotImplementedException();
        }
    }
}