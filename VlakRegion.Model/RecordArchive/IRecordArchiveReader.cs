using System;

namespace VlakRegion.Model.RecordArchive
{
    public interface IRecordArchiveReader : IDisposable
    {
        Int16 Version { get; }

        void Close();

        RecordDescriptor NewRecord();
        void EndRecord();

        Boolean ReadBoolean();
        Byte ReadByte();
        Byte[] ReadBytes();
        Char ReadChar();
        Char[] ReadChars();
        Decimal ReadDecimal();
        Double ReadDouble();
        Int16 ReadInt16();
        Int32 ReadInt32();
        Int64 ReadInt64();
        SByte ReadSByte();
        Single ReadSingle();
        String ReadString();
        UInt16 ReadUInt16();
        UInt32 ReadUInt32();
        UInt64 ReadUInt64();
    }
}
