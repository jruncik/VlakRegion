using System;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl
{
    internal abstract class RecordArchiveWriter : RecordArchive, IRecordArchiveWriter
    {
        protected IWriterImpl _writer;

        public Int16 Version { get; private set; }

        internal RecordArchiveWriter(Stream stream, IWriterImpl writer, Int16 version)
            : base(stream)
        {
            _writer = writer;
            Version = version;

            WriteMasterRecord();
        }

        public void Flush()
        {
            _writer.Flush();
            _stream.Flush();
        }

        public void Close()
        {
            _writer.Close();
        }

        public abstract void NewRecord(RecordDescriptor recordDescriptor);

        public abstract void EndRecord();

        public void Write(bool value)
        {
            _writer.Write(value);
        }

        public void Write(byte value)
        {
            _writer.Write(value);
        }

        public void Write(byte[] value)
        {
            _writer.Write(value);
        }

        public void Write(char value)
        {
            _writer.Write(value);
        }

        public void Write(char[] value)
        {
            _writer.Write(value);
        }

        public void Write(decimal value)
        {
            _writer.Write(value);
        }

        public void Write(double value)
        {
            _writer.Write(value);
        }

        public void Write(short value)
        {
            _writer.Write(value);
        }

        public void Write(int value)
        {
            _writer.Write(value);
        }

        public void Write(long value)
        {
            _writer.Write(value);
        }

        public void Write(sbyte value)
        {
            _writer.Write(value);
        }

        public void Write(float value)
        {
            _writer.Write(value);
        }

        public void Write(string value)
        {
            _writer.Write(value);
        }

        public void Write(ushort value)
        {
            _writer.Write(value);
        }

        public void Write(uint value)
        {
            _writer.Write(value);
        }

        public void Write(ulong value)
        {
            _writer.Write(value);
        }

        protected override void DisposeMe()
        {
            Flush();
            Close();

            _writer.Dispose();
            _writer = null;
        }

        private void WriteMasterRecord()
        {
            NewRecord(new RecordDescriptor(Record.Master, Version));
            EndRecord();
        }
    }
}
