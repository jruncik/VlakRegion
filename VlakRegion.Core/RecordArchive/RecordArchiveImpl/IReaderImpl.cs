using System;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl
{
    internal interface IReaderImpl : IReader, IDisposable
    {
        void Close();
        Int64 Seek(Int32 offset, SeekOrigin origin);
    }
}