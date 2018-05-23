using Quadrilateral_Task2.BL;
using Quadrilateral_Task2.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadrilateral_Task2.Extensions
{
    public static class ListExtensions
    {
        public static Quadrilateral RemoveAndGet(this IList<Quadrilateral> list, Point point)
        {
            lock (list)
            {
                Quadrilateral result = null;
                int index = 0;
                bool isFound = false;
                for (; index < list.Count(); index++)
                {
                    if (QuadrilateralBL.IsInPolygon(list.ElementAt(index).ToArray(), point) == true)
                    {
                        isFound = true;
                        break;
                    }
                }

                if(isFound)
                {
                    result = list.ElementAt(index);
                    list.RemoveAt(index);
                }

                return result;
            }
        }
    }
}
