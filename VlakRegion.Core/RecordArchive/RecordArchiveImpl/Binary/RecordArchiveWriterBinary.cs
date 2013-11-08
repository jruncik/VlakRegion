using System;
using System.Collections.Generic;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl.Binary
{
    internal class RecordArchiveWriterBinary : RecordArchiveWriter
    {
        private const Int64 RecordSizePlaceHolder = 0;
        private readonly Stack<CurrentRecordInfo> _currentRecordInfos;

        internal RecordArchiveWriterBinary(Stream stream, short version)
            : base(stream, new BinaryWriterImpl(stream), version)
        {
            _currentRecordInfos = new Stack<CurrentRecordInfo>();
        }

        public override void NewRecord(RecordDescriptor recordDescriptor)
        {
            _writer.Write((Int32)recordDescriptor.Record);

            _currentRecordInfos.Push(new CurrentRecordInfo(recordDescriptor, _stream.Position));
            _writer.Write(RecordSizePlaceHolder);

            _writer.Write(recordDescriptor.Version);
        }

        public override void EndRecord()
        {
            CurrentRecordInfo currentRecordInfo = _currentRecordInfos.Pop();
            Int64 currentStreamPosition = _stream.Position;
            Int64 recordSize = currentStreamPosition - currentRecordInfo.RecordSizePosition;

            _writer.Seek(currentRecordInfo.RecordSizePosition, SeekOrigin.Begin);
            _writer.Write(recordSize);

            _writer.Seek(0, SeekOrigin.End);
        }
    }
}