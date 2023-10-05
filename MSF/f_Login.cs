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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(850, 720);
            this.passwordtxt.AutoSize = false;
            this.passwordtxt.Size = new Size(this.passwordtxt.Size.Width, 50);
        }


        private void OnLoginClick(object sender, EventArgs e)
        {
            CDataAccess dataAccess = new CDataAccess(); //data access instance

            if (!String.IsNullOrEmpty(usernametxt.Text.Trim()) && !String.IsNullOrEmpty(passwordtxt.Text.Trim()))
            {
                //if the user input is not empty check to see if the user exists
                bool IsReal = dataAccess.LoginAuthentication(usernametxt.Text.Trim(), passwordtxt.Text.Trim());

                if (IsReal) //if true redirect the user to the Main Menu
                {
                    Form oForm = new f_SubMenu(usernametxt.Text.Trim());
                    this.Hide();
                    oForm.Show();
                }
                else
                    MessageBox.Show("Your credentials are not part of the system!");
            }
            else
                MessageBox.Show("Please enter your credentials!");

        }

        private void OnLogout(object sender, EventArgs e)
        {
            Form oForm = new frmEntrance();
            this.Hide();
            oForm.Show();
        }
    }
}
