using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl.Binary
{
    internal class BinaryWriterImpl : IWriterImpl
    {
        private readonly BinaryWriter _writer;

        public BinaryWriterImpl(Stream stream)
        {
            _writer = new BinaryWriter(stream);
        }

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
            _writer.Write(value.Length);
            _writer.Write(value);
        }

        public void Write(char value)
        {
            _writer.Write(value);
        }

        public void Write(char[] value)
        {
            _writer.Write(value.Length);
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

        public void Dispose()
        {
            _writer.Dispose();
        }

        public void Flush()
        {
            _writer.Flush();
        }

        public void Close()
        {
            _writer.Close();
        }

        public long Seek(int offset, SeekOrigin origin)
        {
            return _writer.Seek(offset, origin);
        }
    }
}