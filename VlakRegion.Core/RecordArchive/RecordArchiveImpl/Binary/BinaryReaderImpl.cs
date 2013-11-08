using System;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl.Binary
{
    internal class BinaryReaderImpl : IReaderImpl
    {
        private readonly Stream _stream;
        private readonly BinaryReader _reader;

        public BinaryReaderImpl(Stream stream)
        {
            _stream = stream;
            _reader = new BinaryReader(stream);
        }

        public bool ReadBoolean()
        {
            return _reader.ReadBoolean();
        }

        public byte ReadByte()
        {
            return _reader.ReadByte();
        }

        public byte[] ReadBytes()
        {
            Int32 count = ReadInt32();
            return _reader.ReadBytes(count);
        }

        public char ReadChar()
        {
            return _reader.ReadChar();
        }

        public char[] ReadChars()
        {
            Int32 count = ReadInt32();
            return _reader.ReadChars(count);
        }

        public decimal ReadDecimal()
        {
            return _reader.ReadDecimal();
        }

        public double ReadDouble()
        {
            return _reader.ReadDouble();
        }

        public short ReadInt16()
        {
            return _reader.ReadInt16();
        }

        public int ReadInt32()
        {
            return _reader.ReadInt32();
        }

        public long ReadInt64()
        {
            return _reader.ReadInt64();
        }

        public sbyte ReadSByte()
        {
            return _reader.ReadSByte();
        }

        public float ReadSingle()
        {
            return _reader.ReadSingle();
        }

        public string ReadString()
        {
            return _reader.ReadString();
        }

        public ushort ReadUInt16()
        {
            return _reader.ReadUInt16();
        }

        public uint ReadUInt32()
        {
            return _reader.ReadUInt32();
        }

        public ulong ReadUInt64()
        {
            return _reader.ReadUInt64();
        }

        public void Dispose()
        {
            _reader.Dispose();
        }

        public void Close()
        {
            _reader.Close();
        }

        public long Seek(int offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }
    }
}