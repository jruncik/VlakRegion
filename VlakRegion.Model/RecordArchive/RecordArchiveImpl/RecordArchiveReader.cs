using System;
using System.IO;
using VlakRegion.Model.RecordArchive.Exceptions;

namespace VlakRegion.Model.RecordArchive.RecordArchiveImpl
{
    public class RecordArchiveReader : RecordArchive, IRecordArchiveReader
    {
        private BinaryReader _reader;

        public Int16 Version { get; private set; }

        public RecordArchiveReader(Stream stream)
            : base(stream)
        {
            _reader = new BinaryReader(_stream);

            ReadMasterRecord();
        }

        public void Close()
        {
            _reader.Close();
        }

        public RecordDescriptor NewRecord()
        {
            return RecordDescriptor.Empty;
        }

        public void EndRecord()
        {
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

        protected override void DisposeMe()
        {
            Close();

            _reader.Dispose();
            _reader = null;
        }

        private void ReadMasterRecord()
        {
            RecordDescriptor recordDescriptor = NewRecord();

            if (recordDescriptor.Record != Record.Master)
            {
                throw new RecordArchiveException("Invalid Master record detected!");
            }

            Version = Version;

            EndRecord();
        }
    }
}