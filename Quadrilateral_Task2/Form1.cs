using Quadrilateral_Task2.Classes;
using Quadrilateral_Task2.DTO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Quadrilateral_Task2
{
    public partial class Form1 : Form
    {
        private Pen pen;
        private Brush polygonBrush;
        private Brush pointBrush;
        private Graphics graphics;
        private Quadrilateral quadrilateral;

        public Form1()
        {
            InitializeComponent();
            graphics = panelMain.CreateGraphics();
            pen = new Pen(Brushes.Red, 3f);
            polygonBrush = new SolidBrush(Color.Aqua);
            pointBrush = new SolidBrush(Color.Black);
            quadrilateral = new Quadrilateral();
        }

        private void NewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClearPanel();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                ClearPanel();
                this.quadrilateral = QuadrilateralDTO.Deserialize(openFileDialog1.FileName);
                this.labelCounter.Visible = false;
                this.buttonDraw.Enabled = true;
                graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
                this.buttonPolygonColor.Visible = true;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1 = new SaveFileDialog
            {
                RestoreDirectory = true,
                DefaultExt = "xml",
                CheckPathExists = true,
                Title = "Save your work",
                ValidateNames = true
            };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != string.Empty)
                {
                    QuadrilateralDTO.Serialize(quadrilateral, saveFileDialog1.FileName);               
                }
            }
        }

        #region Initlaize

        private void ClearPanel()
        {
            this.buttonDraw.Enabled = false;
            this.graphics.Clear(Color.White);
            this.labelCounter.Visible = true;
            this.buttonPolygonColor.Visible = false;
            this.labelCounter.Text = "Додайте ще 4 точки щоб утворити чотириктуник";
            this.quadrilateral = new Quadrilateral();
        }

        #endregion

        private void PanelMain_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            Point point = new Point(me.Location.X, me.Location.Y);
            if (!quadrilateral.IsCompleted())
            {
                if (quadrilateral.AddPoint(point) == false)
                {
                    this.buttonDraw.Enabled = true;
                    this.labelCounter.Visible = false;
                }
                else
                {
                    SetTextToLabel(this.labelCounter, string.Format("Додайте ще {0} точки щоб утворити чотириктуник ", 4 - quadrilateral.Count()));
                }
                graphics.FillRectangle(new SolidBrush(quadrilateral.Color), point.X, point.Y, 4, 4);
            }
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            graphics.FillPolygon(new SolidBrush(quadrilateral.Color), quadrilateral.ToArray());
            this.buttonPolygonColor.Visible = true;
        }

        private void ButtonPolygonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            quadrilateral.Color = colorDialog1.Color;
            graphics.FillPolygon(new SolidBrush(colorDialog1.Color), quadrilateral.ToArray());
        }
    }
}
