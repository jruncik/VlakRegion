using System;
using System.Diagnostics;
using System.IO;

namespace VlakRegion.Core.RecordArchive.RecordArchiveImpl
{
    public abstract class RecordArchive : IDisposable
    {
        protected readonly Stream _stream;

        protected bool _disposed;

        protected RecordArchive(Stream stream)
        {
            _stream = stream;
        }

#if DEBUG
        ~RecordArchive()
        {
            if (!_disposed)
            {
                Debug.Assert(false, "Please dispose me!");
            }
        }
#endif

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            _disposed = true;

            if (disposing)
            {
                DisposeMe();
            }
        }

        protected abstract void DisposeMe();
    }
}