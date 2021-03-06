﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.src;

namespace CA
{
    public partial class Form1 : Form
    {
        private Data data;
        private Display display;
        private Neighbor neighbor;
        private Execute execute;

        public Form1()
        {
            InitializeComponent();

            data = new Data();
            display = new Display(pictureBox, data);
            execute = new Execute(display, data);
            neighbor = new Neighbor(data, execute);

            SetLimits();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Menu = new MainMenu();

            MenuItem import = new MenuItem("Import");
            MenuItem export = new MenuItem("Export");

            this.Menu.MenuItems.Add(import);
            this.Menu.MenuItems.Add(export);

            import.MenuItems.Add("Structure file", display.ImportFromFile);
            import.MenuItems.Add("Structure bitmap", display.ImportFromBitmap);
            export.MenuItems.Add("Structure file", display.ExportToFile);
            export.MenuItems.Add("Structure bitmap", display.ExportToBitmap);
            export.MenuItems.Add("Distribution file", display.ExportDistribution);
           
        }

        private void SetLimits()
        {
            sizeXDimensionNum.Minimum = 1;
            sizeXDimensionNum.Maximum = pictureBox.Width / data.CellSize;
            sizeXDimensionNum.Value = sizeXDimensionNum.Maximum;

            sizeYDimensionNum.Minimum = 1;
            sizeYDimensionNum.Maximum = pictureBox.Height / data.CellSize;
            sizeYDimensionNum.Value = sizeYDimensionNum.Maximum;

            grainsAmountNum.Minimum = 1;
            grainsAmountNum.Maximum = 100;
            grainsAmountNum.Value = 10;

            speedNum.Minimum = 1;
            speedNum.Maximum = 100;
            speedNum.Value = 5;

            inclusionsAmountNum.Minimum = 1;
            inclusionsAmountNum.Maximum = 100;
            inclusionsAmountNum.Value = 10;

            sizeInclusionsNum.Minimum = 1;
            sizeInclusionsNum.Maximum = pictureBox.Height / data.CellSize;
            sizeInclusionsNum.Value = 1;

            probabilityUpDown.Minimum = 1;
            probabilityUpDown.Maximum = 100;
            probabilityUpDown.Value = 50;

            grainsAmountToSelectionNum.Minimum = 1;
            grainsAmountToSelectionNum.Maximum = 150;
            grainsAmountToSelectionNum.Value = 3;

            GBNumeric.Value = 1;
            GBNumeric.Minimum = 1;
            GBNumeric.Maximum = 5;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coords = me.Location;

            if (data.IsSelectionClicked == true)
            {
                neighbor.GrainClick(coords, display);
            }
            else
            {
                neighbor.OwnNeighborClick(coords, display);
            }

            if (data.IsBorderyClicked == true)
            {
                neighbor.GrainBorderClick(coords, display);
            }
        }

        private void sizeXDimension_ValueChanged(object sender, EventArgs e)
        {
            data.SizeX = decimal.ToInt32(sizeXDimensionNum.Value);
        }

        private void sizeYDimension_ValueChanged(object sender, EventArgs e)
        {
            data.SizeY = decimal.ToInt32(sizeYDimensionNum.Value);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            neighbor.RandomNeighbor(display);
        }

        private void speed_ValueChanged(object sender, EventArgs e)
        {
            data.Speed = decimal.ToInt32(speedNum.Value);
        }

        private void singleStep_Click(object sender, EventArgs e)
        {
            neighbor.OwnNeighbor();
        }

        private void grainsAmount_ValueChanged(object sender, EventArgs e)
        {
            data.GrainsAmount = decimal.ToInt32(grainsAmountNum.Value);
            data.NumberOfLeftGrains = decimal.ToInt32(grainsAmountNum.Value);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                data.IsPeriodic = true;
            }
            else
            {
                data.IsPeriodic = false;
            }
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            data.Initialize();
            display.Clear();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void sizeInclusionsNum_ValueChanged(object sender, EventArgs e)
        {
            data.InclusionSize = decimal.ToInt32(sizeInclusionsNum.Value);
        }

        private void inclusionsAmountNum_ValueChanged(object sender, EventArgs e)
        {
            data.InclusionsAmount = decimal.ToInt32(inclusionsAmountNum.Value);
        }

        private void inclusionsBefore_Click(object sender, EventArgs e)
        {
            neighbor.RandomInclusionsBefore(display);
        }

        private void inclusionsAfter_Click(object sender, EventArgs e)
        {
            if (data.EndInclusionAfter)
            {
                neighbor.RandomInclusionsAfter(display);
            }
        }

        private void checkBoxInclusion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInclusion.Checked)
            {
                data.InclusionType = true;
            }
            else
            {
                data.InclusionType = false;
            }
        }

        private void probabilityUpDown_ValueChanged(object sender, EventArgs e)
        {
            data.Probability = decimal.ToInt32(probabilityUpDown.Value);
        }

        private void controlStep_Click(object sender, EventArgs e)
        {
            neighbor.OwnShapeNeighbor();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSelection.Checked)
            {
                data.SelectionType = true;
            }
            else
            {
                data.SelectionType = false;
            }

        }

        private void grainsAmountToSelectionNum_ValueChanged(object sender, EventArgs e)
        {
            data.GrainsToSelectionAmount = decimal.ToInt32(grainsAmountToSelectionNum.Value);
        }

        private void selectGrainsButton_Click(object sender, EventArgs e)
        {
            data.IsSelectionClicked = true;
        }

        private void singleStructureStepButton_Click(object sender, EventArgs e)
        {
            neighbor.OwnSelectionNeighbor();
        }

        private void generateWithStructureBtn_Click(object sender, EventArgs e)
        {
            neighbor.RandomNeighborSelection(display);
        }

        private void generateBoundaryBtn_Click(object sender, EventArgs e)
        {
            neighbor.GenerateBorders(display);
        }

        private void GBNumeric_ValueChanged(object sender, EventArgs e)
        {
            data.GbSize = decimal.ToInt32(GBNumeric.Value);
        }

        private void selectBorderGrainBtn_Click(object sender, EventArgs e)
        {
            data.IsBorderyClicked = true;
        }

        private void selectedBordersBtn_Click(object sender, EventArgs e)
        {
            neighbor.ShowSelectedBorders(display);
        }
    }
}
