using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace Quadrilateral_Task2.POCO.Tests
{
    [TestClass()]
    public class QuadrilateralTests
    {
        [TestMethod()]
        public void CenterTest()
        {
            Quadrilateral quadrilateral = new Quadrilateral
            {
                Points = new List<Point> { new Point(0, 0), new Point(10, 0), new Point(0, 4), new Point(10, 4) }
            };
            var center = quadrilateral.Center();
            Assert.AreEqual(5, center.X);
            Assert.AreEqual(2, center.Y);
        }

        [TestMethod()]
        public void AddPointTest()
        {
            Quadrilateral quadrilateral = new Quadrilateral();
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(true, quadrilateral.AddPoint(new Point(0, i)));
            }
            Assert.IsFalse(quadrilateral.IsCompleted());
            Assert.AreEqual(false, quadrilateral.AddPoint(new Point(0, 1234)));
            Assert.IsTrue(quadrilateral.IsCompleted());
        }
    }
}