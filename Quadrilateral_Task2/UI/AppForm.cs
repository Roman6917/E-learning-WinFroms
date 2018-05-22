using Quadrilateral_Task2.BL;
using Quadrilateral_Task2.POCO;
using Quadrilateral_Task2.Extensions;
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
            Reset();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            openFileDialog1 = UI.CreateOpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                quadrilateral = QuadrilateralBL.Deserialize(openFileDialog1.FileName);
                UI.Hide(labelCounter);
                UI.Enable(buttonDraw);
                UI.Show(buttonPolygonColor);
                Graphic.DrawPolygon(graphics, quadrilateral);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = UI.CreateSaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                QuadrilateralBL.Serialize(quadrilateral, saveFileDialog1.FileName);
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
                    UI.Enable(buttonDraw);
                    UI.Hide(labelCounter);
                }
                else
                {
                    UI.SetTextToLabel(labelCounter, string.Format("Додайте ще {0} точки щоб утворити {1}-кутник ", Quadrilateral.Size - quadrilateral.Count(), Quadrilateral.Size));
                }
                Graphic.DrawPoint(graphics, point);
            }
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            Graphic.DrawPolygon(graphics, quadrilateral);
            UI.Show(buttonPolygonColor);
        }

        private void PolygonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                quadrilateral.Color = colorDialog1.Color;
                Graphic.DrawPolygon(graphics, quadrilateral);
            }
        }
    }
}
