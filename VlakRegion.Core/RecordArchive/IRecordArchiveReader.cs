using System;

namespace VlakRegion.Core.RecordArchive
{
    public interface IRecordArchiveReader : IReader, IDisposable
    {
        Int16 Version { get; }

        void Close();

        RecordDescriptor NewRecord();
        void EndRecord();

        void SkipCurrentRecord();
    }
}
