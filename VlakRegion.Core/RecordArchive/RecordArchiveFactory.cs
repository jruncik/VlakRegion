using System;
using System.IO;
using VlakRegion.Core.RecordArchive.RecordArchiveImpl.Binary;

namespace VlakRegion.Core.RecordArchive
{
    public class RecordArchiveFactory
    {
        public IRecordArchiveWriter CreateBinaryWriter(Stream stream, Int16 version)
        {
            return new RecordArchiveWriterBinary(stream, version);
        }

        public IRecordArchiveReader CreateBinaryReader(Stream stream, Int16 version)
        {
            return new RecordArchiveReaderBinary(stream);
        }
    }
}
