using Quadrilateral_Task2.POCO;
using System.Drawing;

namespace Quadrilateral_Task2.Extensions
{
    public static class Graphic
    {
        public static void DrawPolygon(Graphics graphics,  Quadrilateral quadrilateral)
        {
            graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
        }

        public static void DrawPoint(Graphics graphics, Point point)
        {
            graphics.FillRectangle(Brushes.Black, point.X, point.Y, 4, 4);
        }
    }
}
