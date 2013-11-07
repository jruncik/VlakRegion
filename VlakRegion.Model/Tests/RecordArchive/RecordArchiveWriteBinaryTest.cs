using System.IO;
using NUnit.Framework;
using VlakRegion.Model.RecordArchive;

namespace VlakRegion.Model.Tests.RecordArchive
{
    [TestFixture]
    public class RecordArchiveWriteBinaryTest
    {
        //[Test]
        //public void EmptyRecordWrite()
        //{
        //    MemoryStream stream = new MemoryStream(1024);

        //    using (IRecordArchiveWriter _writer = new RecordArchiveWriter(stream, 1))
        //    {
        //        _writer.NewRecord(new RecordDescriptor(Record.Test, 27));
        //        _writer.EndRecord();

        //        _writer.Write(true);
        //        _writer.Write(false);
        //        _writer.Write("Ahoj");
        //        _writer.Close();
        //    }

        //    byte[] binaryData = stream.ToArray();
        //}
    }
}
