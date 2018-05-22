using Quadrilateral_Task2.Classes;
using Quadrilateral_Task2.DTO;
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
            ClearPanel();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            ClearPanel();
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Filter = "(*.xml)|*.xml",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Choose file"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                quadrilateral = QuadrilateralDTO.Deserialize(openFileDialog1.FileName);
                labelCounter.Visible = false;
                buttonDraw.Enabled = true;
                graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
                buttonPolygonColor.Visible = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog
            {
                RestoreDirectory = true,
                DefaultExt = "xml",
                CheckPathExists = true,
                Title = "Save your work",
                ValidateNames = true
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                QuadrilateralDTO.Serialize(quadrilateral, saveFileDialog1.FileName);
            }
        }


        private void ClearPanel()
        {
            buttonDraw.Enabled = false;
            graphics.Clear(Color.White);
            labelCounter.Visible = true;
            buttonPolygonColor.Visible = false;
            labelCounter.Text = "Додайте ще 4 точки щоб утворити чотириктуник";
            quadrilateral = new Quadrilateral();
        }


        private void Main_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            Point point = new Point(me.Location.X, me.Location.Y);
            if (!quadrilateral.IsCompleted())
            {
                if (quadrilateral.AddPoint(point) == false)
                {
                    buttonDraw.Enabled = true;
                    labelCounter.Visible = false;
                }
                else
                {
                    SetTextToLabel(labelCounter, string.Format("Додайте ще {0} точки щоб утворити чотириктуник ", 4 - quadrilateral.Count()));
                }
                graphics.FillRectangle(new SolidBrush(quadrilateral.Color), point.X, point.Y, 4, 4);
            }
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
            buttonPolygonColor.Visible = true;
        }

        private void PolygonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            quadrilateral.Color = colorDialog1.Color;
            graphics.FillPolygon(new SolidBrush(colorDialog1.Color), quadrilateral.ToArray());
        }
    }
}
