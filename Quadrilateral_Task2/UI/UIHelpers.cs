using System.Windows.Forms;

namespace Quadrilateral_Task2.UI
{
    public static class UIHelpers
    {
        public static void SetTextToLabel(Label label, string text)
        {
            label.Text = text;
        }

        public static void Enable(Control controlElement)
        {
            controlElement.Enabled = true;
        }

        public static void Disable(Control controlElement)
        {
            controlElement.Enabled = false;
        }

        public static void Hide(Control controlElement)
        {
            controlElement.Visible = false;
        }

        public static void Show(Control controlElement)
        {
            controlElement.Visible = true;
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

    }
}
