using Quadrilateral_Task2.POCO;
using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace Quadrilateral_Task2.BL
{
    public class QuadrilateralBL
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
                throw new ApplicationException(string.Format("cannot deserialize file {0}", path));
            }
            quadrilateral.Color = Color.FromArgb(quadrilateral.RgbaColor);
            
return quadrilateral;
        }
    }
}
