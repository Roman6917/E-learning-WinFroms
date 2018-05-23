﻿using Quadrilateral_Task2.BL;
using Quadrilateral_Task2.POCO;
using Quadrilateral_Task2.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Quadrilateral_Task2.Utils;

namespace Quadrilateral_Task2
{
    public partial class AppForm : Form
    {
        private Graphics graphics;
        private Quadrilateral quadrilateralToDraw;
        private Quadrilateral activeQquadrilateral;
        private List<Quadrilateral> quadrilaterals;
        private bool isFigureChecked;
        private static int doubleClickCounter;

        public AppForm()
        {
            InitializeComponent();
            graphics = panelMain.CreateGraphics();
            quadrilaterals = new List<Quadrilateral>();
            quadrilateralToDraw = new Quadrilateral();
            isFigureChecked = false;
            doubleClickCounter = 0;
        }

        private void New_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            Reset();
            openFileDialog1 = UI.CreateOpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                quadrilaterals = QuadrilateralBL.DeserializeList(openFileDialog1.FileName);
                Graphic.Redraw(panelMain, graphics, quadrilaterals);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = UI.CreateSaveFileDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                QuadrilateralBL.SerializeList(quadrilaterals, saveFileDialog1.FileName);
            }
        }

        private void PanelMain_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent  = e as MouseEventArgs;
            if (mouseEvent.Button == MouseButtons.Left)
            {
                Point point = new Point(mouseEvent.Location.X, mouseEvent.Location.Y);
                if (quadrilateralToDraw.AddPoint(point) == false && doubleClickCounter == 3)
                {
                    quadrilaterals.Add(quadrilateralToDraw);
                    quadrilateralToDraw = new Quadrilateral();
                    Graphic.Redraw(panelMain, graphics, quadrilaterals);
                    doubleClickCounter = 0;
                }
                else
                {
                    doubleClickCounter++;
                }

                UI.SetTextToLabel(labelCounter, string.Format("Додайте ще {0} точки щоб утворити {1}-кутник ", Quadrilateral.SIZE - quadrilateralToDraw.Count(), Quadrilateral.SIZE));
            }
        }

        private void PolygonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && activeQquadrilateral != null)
            {
                quadrilaterals.Remove(activeQquadrilateral);
                activeQquadrilateral.Color = colorDialog1.Color;
                quadrilaterals.Add(activeQquadrilateral);
                Graphic.Redraw(panelMain, graphics, quadrilaterals);
            }
        }

        private void ShapesMenu_Click(object sender, EventArgs e)
        {
            UI.LoadShapesMenu(shapesMenu, ShapesMenuDropDown_Click);
        }

        private void ShapesMenuDropDown_Click(object sender, EventArgs e)
        {
            string filename = (sender as ToolStripMenuItem).Text;
            List<Quadrilateral> newQuadrilaterals = QuadrilateralBL.LoadFigures(filename);
            quadrilaterals.AddRange(newQuadrilaterals);
            Graphic.Redraw(panelMain, graphics, quadrilaterals);
        }

        private void PanelMain_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent  = e as MouseEventArgs;
            if (mouseEvent.Button == MouseButtons.Right)
            {
                Point point = new Point(mouseEvent.Location.X, mouseEvent.Location.Y);

                if (!isFigureChecked)
                {
                    activeQquadrilateral = quadrilaterals.FirstOrDefault(p => GeometryUtils.IsInPolygon(p.ToArray(), point) == true);
                    if (activeQquadrilateral != null)
                    {
                        isFigureChecked = true;
                        UI.Show(labelFigureChecked, buttonCancel, buttonPolygonColor);
                    }
                }
                else
                {
                    if (activeQquadrilateral == null)
                    {
                        throw new ApplicationException("");
                    }
                    quadrilaterals.Remove(activeQquadrilateral);
                    Point previouseCenter = activeQquadrilateral.Center();
                    int xShifting = previouseCenter.X - point.X;
                    int yShifting = previouseCenter.Y - point.Y;

                    var points = activeQquadrilateral.ToArray();
                    for (int i = 0; i < points.Count(); i++)
                    {
                        points[i].X -= xShifting;
                        points[i].Y -= yShifting;
                    }
                    activeQquadrilateral.Points = points.ToList();
                    quadrilaterals.Add(activeQquadrilateral);
                    Graphic.Redraw(panelMain, graphics, quadrilaterals);
                }
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            isFigureChecked = false;
            UI.Hide(labelFigureChecked, buttonCancel, buttonPolygonColor);
        }
    }
}
