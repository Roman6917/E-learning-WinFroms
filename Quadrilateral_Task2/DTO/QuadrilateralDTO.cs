using Quadrilateral_Task2.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Quadrilateral_Task2.DTO
{
    public class QuadrilateralDTO
    {
        public static void Serialize(Quadrilateral quadrilateral, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Quadrilateral));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                quadrilateral.RgbaColor = quadrilateral.Color.ToArgb();
                formatter.Serialize(fs, quadrilateral);
            }
        }

        public static Quadrilateral Deserialize(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Quadrilateral));
            Quadrilateral quadrilateral = null;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                quadrilateral = (Quadrilateral)formatter.Deserialize(fs);
            }
            
            if (quadrilateral == null)
            {
                throw new ApplicationException(string.Format("cannot read file {0}", path));
            }
            quadrilateral.Color = Color.FromArgb(quadrilateral.RgbaColor);
            return quadrilateral;
        }
    }
}
