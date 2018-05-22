using Quadrilateral_Task2.POCO;
using System.Drawing;
using System.Windows.Forms;

namespace Quadrilateral_Task2
{
    partial class AppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            newToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            newToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            shapesToolStripMenuItem = new ToolStripMenuItem();
            panelMain = new Panel();
            labelCounter = new Label();
            buttonDraw = new Button();
            colorDialog1 = new ColorDialog();
            buttonPolygonColor = new Button();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] {
            newToolStripMenuItem,
            shapesToolStripMenuItem});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1290, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            toolStripSeparator1,
            newToolStripMenuItem1,
            toolStripSeparator2,
            openToolStripMenuItem,
            toolStripSeparator3,
            saveToolStripMenuItem});
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            newToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // newToolStripMenuItem1
            // 
            newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            newToolStripMenuItem1.Size = new System.Drawing.Size(252, 30);
            newToolStripMenuItem1.Text = "New";
            newToolStripMenuItem1.Click += new System.EventHandler(New_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += new System.EventHandler(Open_Click);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += new System.EventHandler(Save_Click);
            // 
            // shapesToolStripMenuItem
            // 
            shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            shapesToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            shapesToolStripMenuItem.Text = "Shapes";
            // 
            // panelMain
            // 
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Location = new System.Drawing.Point(39, 97);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(713, 313);
            panelMain.TabIndex = 1;
            panelMain.DoubleClick += new System.EventHandler(Main_DoubleClick);
            // 
            // labelCounter
            // 
            labelCounter.AutoSize = true;
            labelCounter.BackColor = System.Drawing.Color.White;
            labelCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelCounter.Location = new System.Drawing.Point(151, 48);
            labelCounter.Name = "labelCounter";
            labelCounter.Size = new System.Drawing.Size(520, 25);
            labelCounter.TabIndex = 2;
            labelCounter.Text = "Додайте ще 4 точки щоб утворити чотириктуник";
            // 
            // buttonDraw
            // 
            buttonDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            buttonDraw.Enabled = false;
            buttonDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            buttonDraw.ForeColor = System.Drawing.Color.Black;
            buttonDraw.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            buttonDraw.Location = new System.Drawing.Point(835, 97);
            buttonDraw.Name = "buttonDraw";
            buttonDraw.Size = new System.Drawing.Size(152, 135);
            buttonDraw.TabIndex = 3;
            buttonDraw.Text = "Малювати";
            buttonDraw.UseVisualStyleBackColor = false;
            buttonDraw.Click += new System.EventHandler(Draw_Click);
            // 
            // buttonPolygonColor
            // 
            buttonPolygonColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            buttonPolygonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            buttonPolygonColor.ForeColor = System.Drawing.Color.Black;
            buttonPolygonColor.Location = new System.Drawing.Point(855, 265);
            buttonPolygonColor.Name = "buttonPolygonColor";
            buttonPolygonColor.Size = new System.Drawing.Size(105, 93);
            buttonPolygonColor.TabIndex = 4;
            buttonPolygonColor.Text = "Змінити колір";
            buttonPolygonColor.UseVisualStyleBackColor = false;
            buttonPolygonColor.Visible = false;
            buttonPolygonColor.Click += new System.EventHandler(PolygonColor_Click);
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // AppForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Navy;
            ClientSize = new System.Drawing.Size(1290, 570);
            Controls.Add(buttonPolygonColor);
            Controls.Add(buttonDraw);
            Controls.Add(labelCounter);
            Controls.Add(panelMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AppForm";
            Text = "Drawing Qquadrilaterals";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        #region Form components control

        /// <summary>
        /// Reset form to initial state
        /// </summary>
        private void Clear()
        {
            buttonDraw.Enabled = false;
            graphics.Clear(Color.White);
            labelCounter.Visible = true;
            buttonPolygonColor.Visible = false;
            labelCounter.Text = "Додайте ще 4 точки щоб утворити чотириктуник";
            quadrilateral = new Quadrilateral();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem shapesToolStripMenuItem;
        private Panel panelMain;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private Label labelCounter;
        private Button buttonDraw;
        private ColorDialog colorDialog1;
        private Button buttonPolygonColor;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}

