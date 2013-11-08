namespace VlakRegion.Core.RecordArchive
{
    public interface IReader
    {
        bool ReadBoolean();
        byte ReadByte();
        byte[] ReadBytes();
        decimal ReadDecimal();
        double ReadDouble();
        char ReadChar();
        char[] ReadChars();
        short ReadInt16();
        int ReadInt32();
        long ReadInt64();
        sbyte ReadSByte();
        float ReadSingle();
        string ReadString();
        ushort ReadUInt16();
        uint ReadUInt32();
        ulong ReadUInt64();
    }
}
