using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Windows.Forms;

namespace Quadrilateral_Task2.Utils.Tests
{
    [TestClass()]
    public class UITests
    {
        [TestMethod()]
        public void SetTextToLabelTest()
        {
            Label label = new Label { Text = "none" };
            string newText = "new text";
            UI.SetTextToLabel(label, newText);
            Assert.AreEqual(newText, label.Text);
        }

        [TestMethod()]
        public void EnableTest()
        {
            Control[] controls = new Control[] { new Button { Enabled = false } };
            UI.Enable(controls);
            Assert.IsTrue(controls.Any(p => p.Enabled == true));

        }

        [TestMethod()]
        public void DisableTest()
        {
            Control[] controls = new Control[]
            {
                new Button { Enabled = true },
                new Button { Enabled = true },
                new Button { Enabled = true },
                new Button { Enabled = true }
            };
            UI.Disable(controls);
            Assert.IsTrue(controls.Any(p => p.Enabled == false));
        }

        [TestMethod()]
        public void HideTest()
        {
            Control[] controls = new Control[]
             {
                new Button { Visible = true },
                new Button { Visible = true },
                new Button { Visible = true },
                new Button { Visible = true }
             };
            UI.Hide(controls);
            Assert.IsTrue(controls.Any(p => p.Visible == false));
        }

        [TestMethod()]
        public void ShowTest()
        {
            Control[] controls = new Control[]
             {
                new Button { Visible = false },
                new Button { Visible = false },
                new Button { Visible = false },
                new Button { Visible = false }
             };
            UI.Show(controls);
            Assert.IsTrue(controls.Any(p => p.Visible == true));
        }

        [TestMethod()]
        public void CreateOpenFileDialogTest()
        {
            Assert.IsNotNull(UI.CreateOpenFileDialog());
        }

        [TestMethod()]
        public void CreateInformationWindowTest()
        {
            Assert.IsNotNull(UI.CreateInformationWindow());

        }

        [TestMethod()]
        public void CreateSaveFileDialogTest()
        {
            Assert.IsNotNull(UI.CreateSaveFileDialog());
        }
    }
}