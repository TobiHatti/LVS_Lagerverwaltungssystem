﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LVS_Lagerverwaltungssystem_PCUI
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 500;
        }

        private void btn_main_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool mouseDown;
        private Point lastLocation;

        private void panel_main_title_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel_main_title_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel_main_title_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_elements.Visible = true;
        }

        private void Disable_all_Panels()
        {
            panel_elements.Visible = false;
            panel_categories.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Disable_all_Panels();
            panel_categories.Left = 205;
            panel_categories.Visible = true;
            
        }
    }
}