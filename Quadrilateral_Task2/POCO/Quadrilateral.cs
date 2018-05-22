using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Quadrilateral_Task2.POCO
{
    [Serializable]
    public class Quadrilateral
    {
        public const uint Size = 4;
        public List<Point> Points { get; set; }
        public int RgbaColor { get; set; }
        public Color Color { get; set; }

        public Quadrilateral()
        {
            Points = new List<Point>();
            Color = Color.Aqua;
        }

        public Quadrilateral(params Point[] points)
        {
            if (points.Count() != Quadrilateral.Size)
            {
                throw new ArgumentException(string.Format("polygon must contain only {0} points", Quadrilateral.Size));
            }

            Points = new List<Point>(points);
        }

        public int Count()
        {
            return Points.Count();
        }

        public bool IsCompleted()
        {
            return Points.Count() == Size && Points.TrueForAll(p => p != null);
        }

        public bool AddPoint(Point point)
        {
            Points.Add(point);
            if (Points.Count == Quadrilateral.Size)
            {
                return false;
            }
            return true;
        }
 
        public Point[] ToArray()
        {
            return Points.ToArray();
        }
    }
}
