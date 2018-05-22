using Quadrilateral_Task2.BL;
using System.Windows.Forms;

namespace Quadrilateral_Task2.Extensions
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

        public static void LoadShapesMenu(ToolStripMenuItem toolStripMenuItem)
        {
            toolStripMenuItem.DropDownItems.Clear();
            var figures = QuadrilateralBL.LoadFiguresList();
            foreach (var item in figures)
            {
                toolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(item));
            }
        }
    }
}
