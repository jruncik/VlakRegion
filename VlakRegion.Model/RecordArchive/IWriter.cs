using System;

namespace VlakRegion.Model.RecordArchive
{
    public interface IWriter
    {
        void Write(Boolean value);
        void Write(Byte value);
        void Write(Byte[] value);
        void Write(Char value);
        void Write(Char[] value);
        void Write(Decimal value);
        void Write(Double value);
        void Write(Int16 value);
        void Write(Int32 value);
        void Write(Int64 value);
        void Write(SByte value);
        void Write(Single value);
        void Write(String value);
        void Write(UInt16 value);
        void Write(UInt32 value);
        void Write(UInt64 value);
    }
}