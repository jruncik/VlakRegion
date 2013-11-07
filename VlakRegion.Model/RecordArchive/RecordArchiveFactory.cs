using System;
using System.IO;
using VlakRegion.Model.RecordArchive.RecordArchiveImpl;
using VlakRegion.Model.RecordArchive.RecordArchiveImpl.Binary;

namespace VlakRegion.Model.RecordArchive
{
    public class RecordArchiveFactory
    {
        public IRecordArchiveWriter CreateBinaryWriter(Stream stream, Int16 version)
        {
            return new RecordArchiveWriterBinary(stream, version);
        }

        public IRecordArchiveReader CreateBinaryReader(Stream stream, Int16 version)
        {
            return new RecordArchiveReader(stream);
        }
    }
}
