using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrilateral_Task2.Classes
{
    [Serializable]
    class Quadrilateral
    {
        public const uint Size = 4;
        public List<Point> Points { get; set; }
        public Color Color { get; set; }

        public Quadrilateral()
        {
            Points = new List<Point>();
        }

        public int Count()
        {
            return Points.Count();
        }

        public bool IsCompleted()
        {
            return Points.TrueForAll(p => p != null);
        }

        public bool AddPoint(Point point)
        {
            this.Points.Add(point);
            if (this.Points.Count == Quadrilateral.Size)
            {
                return false;
            }
            return true;
        }

        public Quadrilateral(params Point[] points)
        {
            if (points.Count() != Quadrilateral.Size)
            {
                throw new ArgumentException("polygon must contain only 4 points");
            }

            this.Points = new List<Point>(points);
        }

        public Point[] ToArray()
        {
            return Points.ToArray();
        }
    }
}
