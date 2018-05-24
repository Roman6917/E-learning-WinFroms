using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Quadrilateral_Task2.Utils.Tests
{
    [TestClass()]
    public class GeometryUtilsTests
    {
        [TestMethod()]
        public void IsInPolygonTest()
        {
            Point[] points = new Point[]
            {
                new Point(0,0),
                new Point(10,0),
                new Point(99,97),
                new Point(0,10)
            };
            Point point = new Point(5, 7);

            Assert.AreEqual(true, Geometry.IsInPolygon(points, point));

            point = new Point(-1,2 );

            Assert.AreEqual(false, Geometry.IsInPolygon(points, point));

        }
    }
}