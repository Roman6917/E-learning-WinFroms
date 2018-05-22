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

        public static Quadrilateral LoadFigure(string fileName)
        {
            string path = GetDataDirectoryPath() + fileName;
            if (!File.Exists(path))
            {
                throw new IOException(string.Format("can not find file : {0}", path));
            }

            Quadrilateral quadrilateral = QuadrilateralBL.Deserialize(path);

            return quadrilateral;
        }

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

        #region IO helpers

        public const string DATA_FOLDER_NAME = "Data";

        private static string GetDataDirectoryPath()
        {
            return Directory.GetCurrentDirectory().Replace("bin\\Debug", DATA_FOLDER_NAME);
        }

        #endregion

    }
}
