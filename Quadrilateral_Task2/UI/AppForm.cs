using Quadrilateral_Task2.BLL;
using Quadrilateral_Task2.POCO;
using Quadrilateral_Task2.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quadrilateral_Task2
{
    public partial class AppForm : Form
    {
        private Graphics graphics;
        private Quadrilateral quadrilateral;

        public AppForm()
        {
            InitializeComponent();
            graphics = panelMain.CreateGraphics();
            quadrilateral = new Quadrilateral();
        }

        private void New_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            openFileDialog1 = UIHelpers.CreateOpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                quadrilateral = QuadrilateralBLL.Deserialize(openFileDialog1.FileName);
                UIHelpers.Hide(labelCounter);
                UIHelpers.Enable(buttonDraw);
                UIHelpers.Show(buttonPolygonColor);
                graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = UIHelpers.CreateSaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                QuadrilateralBLL.Serialize(quadrilateral, saveFileDialog1.FileName);
            }
        }





        private void Main_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            Point point = new Point(me.Location.X, me.Location.Y);
            if (!quadrilateral.IsCompleted())
            {
                if (quadrilateral.AddPoint(point) == false)
                {
                    UIHelpers.Enable(buttonDraw);
                    UIHelpers.Hide(labelCounter);
                }
                else
                {
                    UIHelpers.SetTextToLabel(labelCounter, string.Format("Додайте ще {0} точки щоб утворити чотириктуник ", 4 - quadrilateral.Count()));
                }
                graphics.FillRectangle(new SolidBrush(quadrilateral.Color), point.X, point.Y, 4, 4);
            }
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
            UIHelpers.Show(buttonPolygonColor);
        }

        private void PolygonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            quadrilateral.Color = colorDialog1.Color;
            graphics.FillPolygon(new SolidBrush(colorDialog1.Color), quadrilateral.ToArray());
        }
    }
}
