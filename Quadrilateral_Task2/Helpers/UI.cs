using Quadrilateral_Task2.BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Quadrilateral_Task2.Helpers
{
    public static class UI
    {
        public static void SetTextToLabel(Label label, string text)
        {
            label.Text = text;
        }

        public static void Enable(params Control[] controlElements)
        {
            foreach (var item in controlElements)
            {
                item.Enabled = true;
            }
        }

        public static void Disable(params Control[] controlElements)
        {
            foreach (var item in controlElements)
            {
                item.Enabled = false;
            }
        }       

        public static void Hide(params Control[] controlElements)
        {
            foreach (var item in controlElements)
            {
                item.Visible = false;
            }
        }

        public static void Show(params Control[] controlElements)
        {
            foreach (var item in controlElements)
            {
                item.Visible = true;
            }
        }

        public static OpenFileDialog CreateOpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "(*.xml)|*.xml",
                RestoreDirectory = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Title = "Choose file"
            };

            return openFileDialog;
        }

        public static SaveFileDialog CreateSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = true,
                DefaultExt = "xml",
                CheckPathExists = true,
                Title = "Save your work",
                ValidateNames = true
            };

            return saveFileDialog;
        }

        public delegate void ShapesMenuDropDown_Click(object sender, EventArgs e);

        public static void LoadShapesMenu(ToolStripMenuItem toolStripMenuItem, ShapesMenuDropDown_Click function)
        {
            var figures = QuadrilateralBL.LoadFiguresList();
            toolStripMenuItem.DropDownItems.Clear();
            List<ToolStripMenuItem> ul = new List<ToolStripMenuItem>();
            foreach (var item in figures)
            {
                ToolStripMenuItem li = new ToolStripMenuItem(item)
                {
                    Size = new Size(252, 30)
                };
                li.Click += new EventHandler(function);
                ul.Add(li);
            }
            toolStripMenuItem.DropDownItems.AddRange(ul.ToArray());
        }


    }
}
