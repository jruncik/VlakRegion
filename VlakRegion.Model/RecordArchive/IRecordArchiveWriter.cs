using System;

namespace VlakRegion.Model.RecordArchive
{
    public interface IRecordArchiveWriter : IWriter
    {
        Int16 Version { get; }

        void NewRecord(RecordDescriptor recordDescriptor);
        void EndRecord();
    }
}