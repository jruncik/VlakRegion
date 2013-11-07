using System;
using NUnit.Framework;
using AR = VlakRegion.Model.RecordArchive;

namespace VlakRegion.Model.Tests
{
    [TestFixture]
    public class VersionTest
    {
        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ParseErrorNotEnoughtParams()
        {
            Version.Parse("1.2.3");
        }

        [Test]
        public void ParseOk()
        {
            Version version = Version.Parse("1.2.3.4");

            Assert.AreEqual(version.Major, 1);
            Assert.AreEqual(version.Minor, 2);
            Assert.AreEqual(version.Build, 3);
            Assert.AreEqual(version.Revision, 4);
        }
    }
}
