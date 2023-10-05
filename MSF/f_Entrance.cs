using System;
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
    public partial class frmEntrance : Form
    {
        public frmEntrance()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(850, 720);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form oForm = new frmLogin();
            this.Hide();
            oForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form oForm = new frmHowToPlay();
            this.Hide();
            oForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form oForm = new frmHighestScore();
            this.Hide();
            oForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form oForm = new frmRegistration();
            this.Hide();
            oForm.Show();
        }
    }
}
