using System;
using NUnit.Framework;

namespace VlakRegion.Core.Tests
{
    [TestFixture]
    public class VersionTest
    {
        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ParseErrorNotEnoughtParams()
        {
            System.Version.Parse("1.2.3");
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ParseErrorWrongParams()
        {
            System.Version.Parse("1.2.3.Test");
        }

        [Test]
        public void ParseOk()
        {
            System.Version version = System.Version.Parse("1.2.3.4");

            Assert.AreEqual(version.Major, 1);
            Assert.AreEqual(version.Minor, 2);
            Assert.AreEqual(version.Build, 3);
            Assert.AreEqual(version.Revision, 4);
        }
    }
}
