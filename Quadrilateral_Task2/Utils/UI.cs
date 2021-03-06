﻿using Quadrilateral_Task2.BL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quadrilateral_Task2.Utils
{
    public static class UI
    {
        #region infromation message 
        private const string INFORMATION_MESSAGE = "Загальне :\n" +
                "\t1) Для того щоб намалювати чотирикутник, клікніть два\n" +
                "\tрази мишкою" +
                "на полотні(це додасть одну його точку).\n" +
                "\t2) Повторіть цю дію ще 3 рази і у вас з'явиться чотирикутник.\n" +
                "\t3) Якщо нажмете на нього правою кнопкою миші, у вас\n" +
                "\t з'явиться підказка, що ви вибрали цей чотириктуник.\n" +
                "\t4) Якщо ще раз нажмете правою кнопокю на полотні, то\n" +
                "\t ваш чотирикутник" +
                "переміститься в цю точку.\n" +
                "\t5) Нажавши на кнопку змінити колір, ви зміните колір.\n" +
                "File :\n" +
                "\tЩоб зберегти малюнок нажміть кнопку 'Save'.\n" +
                "\tЩоб створити новий малюнок нажміть кнопку 'New'.\n" +
                "\tЩоб відкрити якусь зі своїх робіт, нажміть кнопку 'Open'\n" +
                "\tі виберіть відповідний файл.\n" +
                 "Shapes :\n" +
                "\tЯкщо ви збережете свою роботу в папку 'Data' в проекті\n" +
                "\tто в меню 'Shapes'\n" +
                "\tваш малюнок буде збережено як шаблон\n" +
                "\t(ви зможете  застосувати його до поточного малюнку і далі предагувати)";

        #endregion

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

        public static DialogResult CreateInformationWindow()
        {
            string caption = "Information box";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            return MessageBox.Show(INFORMATION_MESSAGE, caption, buttons);
        }

        public delegate void ShapesMenuDropDown_Click(object sender, EventArgs e);

        public static void LoadShapesMenu(ToolStripMenuItem toolStripMenuItem, ShapesMenuDropDown_Click function)
        {
            var figures = QuadrilateralBL.LoadFiguresList();
            toolStripMenuItem.DropDownItems.Clear();
            List<ToolStripMenuItem> ul = new List<ToolStripMenuItem>();
            foreach (var item in figures)
            {
                ToolStripMenuItem li = new ToolStripMenuItem(item);
                li.Click += new EventHandler(function);
                ul.Add(li);
            }
            toolStripMenuItem.DropDownItems.AddRange(ul.ToArray());
        }
    }
}
