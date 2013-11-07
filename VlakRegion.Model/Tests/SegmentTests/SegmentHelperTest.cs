using NUnit.Framework;
using VlakRegion.Model.Exceptions;
using VlakRegion.Model.Segments;
using VlakRegion.Model.TrackObjects;

namespace VlakRegion.Model.Tests.SegmentTests
{
    [TestFixture]
    public class SegmentHelperTest
    {
        private TrackObject _st1;
        private TrackObject _st2;
        private TrackObject _st3;

        private Segment _seg1;
        private Segment _seg2;

        [SetUp]
        public void SetUp()
        {
            _st1 = new RailwayStation("St_1");
            _st2 = new RailwayStation("St_2");
            _st3 = new RailwayStation("St_3");

            _seg1 = new Segment(_st1, _st2, 15);
            _seg2 = _seg1.Insert(_st1, _st3, 40);
        }

        [Test]
        public void GetSegmantAtDistanceFromBeginingFirstSegmentTest()
        {
            Segment found = _seg1.GetSegmantAtDistance(_st1, 5);
            Assert.AreEqual(_seg1, found);
        }

        [Test]
        public void GetSegmantAtDistanceFromBeginingSecondSegmentTest()
        {
            Segment found = _seg1.GetSegmantAtDistance(_st1, 20);
            Assert.AreEqual(_seg2, found);
        }

        [Test]
        public void GetSegmantAtDistanceFromEndFirstSegmentTest()
        {
            Segment found = _seg2.GetSegmantAtDistance(_st3, 5);
            Assert.AreEqual(_seg2, found);
        }

        [Test]
        public void GetSegmantAtDistanceFromEndSecondSegmentTest()
        {
            Segment found = _seg2.GetSegmantAtDistance(_st3, 30);
            Assert.AreEqual(_seg1, found);
        }

        [Test]
        [ExpectedException(typeof(VrException))]
        public void GetSegmantAtDistanceFromEndSecondSegmentNotExistingTrackObjectTest()
        {
            Segment found = _seg1.GetSegmantAtDistance(_st3, 30);
            Assert.AreEqual(_seg1, found);
        }

        [Test]
        [ExpectedException(typeof(VrException))]
        public void GetSegmantAtDistanceFromEndFirstSegmentNotExistingTrackObjectTest()
        {
            Segment found = _seg1.GetSegmantAtDistance(_st3, 5);
            Assert.AreEqual(_seg1, found);
        }

        [Test]
        public void AppendAfterTest()
        {
            TrackObject beginStation = new RailwayStation("Begin");
            TrackObject endStation = new RailwayStation("End");
            TrackObject newEndStation = new RailwayStation("NewEnd");

            Segment source = new Segment(beginStation, endStation, 10);

            Segment appended = source.Insert(beginStation, newEndStation, 15);

            Assert.AreEqual(appended.To, newEndStation);
            Assert.AreEqual(appended.From, endStation);
            Assert.AreEqual(appended.Distance, 5);

            Assert.AreEqual(appended.Prev, source);
            Assert.AreEqual(appended.Next, null);

            Assert.AreEqual(source.Prev, null);
            Assert.AreEqual(source.Next, appended);
        }

        [Test]
        public void AppendBeforeTest()
        {
            TrackObject beginStation = new RailwayStation("Begin");
            TrackObject endStation = new RailwayStation("End");
            TrackObject newBegin = new RailwayStation("NewBegin");

            Segment source = new Segment(beginStation, endStation, 10);

            Segment appended = source.Insert(endStation, newBegin, 25);

            Assert.AreEqual(appended.From, newBegin);
            Assert.AreEqual(appended.To, beginStation);
            Assert.AreEqual(appended.Distance, 15);

            Assert.AreEqual(appended.Next, source);
            Assert.AreEqual(appended.Prev, null);

            Assert.AreEqual(source.Prev, appended);
            Assert.AreEqual(source.Next, null);
        }

        [Test]
        public void InsertSimpleFromFirstTest()
        {
            TrackObject beginStation = new RailwayStation("Begin");
            TrackObject endStation = new RailwayStation("End");
            TrackObject middleStation = new RailwayStation("Middle");

            Segment originSegment = new Segment(beginStation, endStation, 20);

            Segment inserted = originSegment.Insert(beginStation, middleStation, 5);

            Assert.AreEqual(inserted.From, beginStation);
            Assert.AreEqual(inserted.To, middleStation);
            Assert.AreEqual(inserted.Distance, 5);

            Assert.AreEqual(originSegment.From, middleStation);
            Assert.AreEqual(originSegment.To, endStation);
            Assert.AreEqual(originSegment.Distance, 15);

            Assert.AreEqual(inserted.Prev, null);
            Assert.AreEqual(inserted.Next, originSegment);

            Assert.AreEqual(originSegment.Prev, inserted);
            Assert.AreEqual(originSegment.Next, null);
        }

        [Test]
        public void InsertSimpleFromLastTest()
        {
            TrackObject beginStation = new RailwayStation("Begin");
            TrackObject endStation = new RailwayStation("End");
            TrackObject middleStation = new RailwayStation("Middle");

            Segment originSegment = new Segment(beginStation, endStation, 20);

            Segment inserted = originSegment.Insert(endStation, middleStation, 5);

            Assert.AreEqual(inserted.From, middleStation);
            Assert.AreEqual(inserted.To, endStation);
            Assert.AreEqual(inserted.Distance, 5);

            Assert.AreEqual(originSegment.From, beginStation);
            Assert.AreEqual(originSegment.To, middleStation);
            Assert.AreEqual(originSegment.Distance, 15);

            Assert.AreEqual(inserted.Prev, originSegment);
            Assert.AreEqual(inserted.Next, null);

            Assert.AreEqual(originSegment.Prev, null);
            Assert.AreEqual(originSegment.Next, inserted);
        }

        [Test]
        public void InsertFromFirstTest()
        {
            TrackObject st22 = new RailwayStation("St_2_2");
            Segment inserted = _seg1.Insert(_st1, st22, 20);

            Assert.AreEqual(_seg1.From, _st1);
            Assert.AreEqual(_seg1.To, _st2);
            Assert.AreEqual(_seg1.Distance, 15);

            Assert.AreEqual(inserted.From, _st2);
            Assert.AreEqual(inserted.To, st22);
            Assert.AreEqual(inserted.Distance, 5);

            Assert.AreEqual(_seg2.From, st22);
            Assert.AreEqual(_seg2.To, _st3);
            Assert.AreEqual(_seg2.Distance, 20);


            Assert.AreEqual(_seg1.Prev, null);
            Assert.AreEqual(_seg1.Next, inserted);

            Assert.AreEqual(inserted.Prev, _seg1);
            Assert.AreEqual(inserted.Next, _seg2);

            Assert.AreEqual(_seg2.Prev, inserted);
            Assert.AreEqual(_seg2.Next, null);
        }

        [Test]
        public void InsertFromLastTest()
        {
            TrackObject st12 = new RailwayStation("St_1_2");
            Segment inserted = _seg2.Insert(_st3, st12, 35);

            Assert.AreEqual(_seg1.From, _st1);
            Assert.AreEqual(_seg1.To, st12);
            Assert.AreEqual(_seg1.Distance, 5);

            Assert.AreEqual(inserted.From, st12);
            Assert.AreEqual(inserted.To, _st2);
            Assert.AreEqual(inserted.Distance, 10);

            Assert.AreEqual(_seg2.From, _st2);
            Assert.AreEqual(_seg2.To, _st3);
            Assert.AreEqual(_seg2.Distance, 25);


            Assert.AreEqual(_seg1.Prev, null);
            Assert.AreEqual(_seg1.Next, inserted);

            Assert.AreEqual(inserted.Prev, _seg1);
            Assert.AreEqual(inserted.Next, _seg2);

            Assert.AreEqual(_seg2.Prev, inserted);
            Assert.AreEqual(_seg2.Next, null);
        }
    }
}
