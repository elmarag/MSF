﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSF
{
    public partial class frmHowToPlay : Form
    {
        public frmHowToPlay()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(850, 720);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form oForm = new frmEntrance();
            oForm.Show();
        }

        private void frmHowToPlay_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
