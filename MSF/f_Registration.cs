using FluentValidation.Results;
using FluentValidation;
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
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(850, 720);
        }


        private void OnRegistrationClick(object sender, EventArgs e)
        {

            CDataAccess db = new CDataAccess(); //instance of CDataAccess
            bool DoesExist = db.UsernameAuthentication(usernametxt.Text.Trim()); //Checking if the username entered exists
            bool DoesEmailExist = db.EmailAuthentication(emailtxt.Text.Trim());

            CPlayer player = new CPlayer(); //instance of the employee class

            player.FirstName = firstnametxt.Text.Trim();
            player.LastName = lastnametxt.Text.Trim();
            player.Username = usernametxt.Text.Trim();
            player.Email = emailtxt.Text.Trim();
            player.Password = passwordtxt.Text.Trim();


            CPlayerValidator validator = new CPlayerValidator();
            var results = validator.Validate(player); //abstract function for the validation of the Employee registration form

            if (results.IsValid == false) //if errors present them to the user
            {
                foreach (ValidationFailure failure in results.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Registration failed!");
                }
            }
            else
            {
                try
                {
                    if (DoesExist) //if the username exists ask the user for a new one
                    {
                        MessageBox.Show("This username already exists, please choose another one!");
                    }
                    if(DoesEmailExist)
                    {
                        MessageBox.Show("This email already exists, please choose another one!");
                    }
                    else
                    {
                        //enter the new user information into the database
                        db.InsertPlayers(firstnametxt.Text.Trim(), lastnametxt.Text.Trim(), usernametxt.Text.Trim(), emailtxt.Text.Trim(), passwordtxt.Text.Trim());
                        MessageBox.Show("Registration was successful!");
                        this.Hide();
                        Form oForm = new frmEntrance();
                        oForm.Show();
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "Unsuccessful registration!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmEntrance();
            this.Hide();
            frm.Show();
        }
    }
}
