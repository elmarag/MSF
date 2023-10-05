using MSF.Data;
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
    public partial class f_Profile : Form
    {
        public f_Profile(String username)
        {
            InitializeComponent();
            usernametxt.Text = username;
            this.ClientSize = new System.Drawing.Size(850, 720);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form oForm = new f_SubMenu(usernametxt.Text);
            this.Hide();
            oForm.Show();
        }

        private void f_Profile_Load(object sender, EventArgs e)
        {
            try
            {
                CDataAccess dataAccess = new CDataAccess();
                var list = dataAccess.RetrieveInfo(usernametxt.Text);
                firstnametxt.Text = list[0].FirstName;
                lastnametxt.Text = list[0].LastName;
                emailtxt.Text = list[0].Email;
            }
            catch
            {
                MessageBox.Show("You have to be registered.");
            }

        }
    }
}
