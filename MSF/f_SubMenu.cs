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
    public partial class f_SubMenu : Form
    {
        public f_SubMenu(String username)
        {
            InitializeComponent();
            label3.Text = username;
            this.ClientSize = new System.Drawing.Size(850, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form oForm = new frmEntrance();
            this.Hide();
            oForm.Show();
        }

        private void ViewProfile_Click(object sender, EventArgs e)
        {
            Form oForm = new f_Profile(label3.Text);
            this.Hide();
            oForm.Show();
        }

        private void playGame_Click(object sender, EventArgs e)
        {
            Form oForm = new f_Level1();
            this.Hide();
            oForm.Show();
        }
    }
}
