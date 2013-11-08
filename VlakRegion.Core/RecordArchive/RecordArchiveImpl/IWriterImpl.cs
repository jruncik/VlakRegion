using System;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl
{
    internal interface IWriterImpl : IWriter, IDisposable
    {
        void Flush();
        void Close();
        Int64 Seek(Int32 offset, SeekOrigin origin);
    }
}