using System;

namespace VlakRegion.Core.RecordArchive
{
    public struct RecordDescriptor
    {
        public static readonly RecordDescriptor Empty = new RecordDescriptor(Record.Unknown, 0);

        public Record Record;
        public Int16 Version;

        public RecordDescriptor(Record record, short version)
        {
            Record = record;
            Version = version;
        }
    }
}