using System;

namespace VlakRegion.Core.RecordArchive
{
    public interface IRecordArchiveWriter : IWriter, IDisposable
    {
        Int16 Version { get; }

        void NewRecord(RecordDescriptor recordDescriptor);
        void EndRecord();
    }
}