using Quadrilateral_Task2.POCO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Quadrilateral_Task2.BL
{
    public class QuadrilateralBL
    {
        public static List<string> LoadFiguresList()
        {
            List<string> files = null;
            string path = GetDataDirectoryPath();
            if (Directory.Exists(path))
            {
                files = new List<string>(Directory.GetFiles(path).Where(p => Path.GetExtension(p) == ".xml").Select(q => Path.GetFileName(q)));
            }

            return files;
        }

        public static List<Quadrilateral> LoadFigures(string fileName)
        {
            string path = GetDataDirectoryPath() + "\\" + fileName;
            if (!File.Exists(path))
            {
                throw new IOException(string.Format("can not find file : {0}", path));
            }
            List<Quadrilateral> quadrilaterals = QuadrilateralBL.DeserializeList(path);
            
            return quadrilaterals;
        }

        public static void SerializeList(List<Quadrilateral> quadrilaterals, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Quadrilateral>));
            quadrilaterals.ForEach(p => p.RgbaColor = p.Color.ToArgb());
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, quadrilaterals);
            }
        }

        public static List<Quadrilateral> DeserializeList(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Quadrilateral>));
            List<Quadrilateral> quadrilaterals = null;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                quadrilaterals = (List<Quadrilateral>)formatter.Deserialize(fs);
            }

            if (quadrilaterals == null)
            {
                throw new ApplicationException(string.Format("cannot deserialize file {0}", path));
            }
            quadrilaterals.ForEach(p => p.Color = Color.FromArgb(p.RgbaColor));

            return quadrilaterals;
        }

        #region IO helpers

        public const string DATA_FOLDER_NAME = "Data";

        private static string GetDataDirectoryPath()
        {
            return Directory.GetCurrentDirectory().Replace("bin\\Debug", DATA_FOLDER_NAME);
        }

        #endregion


        public static bool IsInPolygon(Point[] poly, Point point)
        {
            var coef = poly.Skip(1)
                .Select((p, i) =>
                (point.Y - poly[i].Y) * (p.X - poly[i].X) - (point.X - poly[i].X) * (p.Y - poly[i].Y)).ToList();

            if (coef.Any(p => p == 0))
            {
                return true;
            }

            for (int i = 1; i < coef.Count(); i++)
            {
                if (coef[i] * coef[i - 1] < 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
