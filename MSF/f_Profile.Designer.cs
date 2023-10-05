namespace MSF
{
    partial class f_Profile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Profile));
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.lastname = new System.Windows.Forms.Label();
            this.lastnametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.firstnametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(806, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 22);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(174, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 52);
            this.label1.TabIndex = 11;
            this.label1.Text = "PROFILE INFORMATION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(224, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 26);
            this.label6.TabIndex = 29;
            this.label6.Text = "Email:";
            // 
            // emailtxt
            // 
            this.emailtxt.BackColor = System.Drawing.Color.Black;
            this.emailtxt.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailtxt.ForeColor = System.Drawing.Color.White;
            this.emailtxt.Location = new System.Drawing.Point(348, 319);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.ReadOnly = true;
            this.emailtxt.Size = new System.Drawing.Size(288, 28);
            this.emailtxt.TabIndex = 28;
            this.emailtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lastname
            // 
            this.lastname.AutoSize = true;
            this.lastname.BackColor = System.Drawing.Color.Black;
            this.lastname.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastname.ForeColor = System.Drawing.Color.White;
            this.lastname.Location = new System.Drawing.Point(206, 237);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(111, 26);
            this.lastname.TabIndex = 27;
            this.lastname.Text = "Last Name:";
            // 
            // lastnametxt
            // 
            this.lastnametxt.BackColor = System.Drawing.Color.Black;
            this.lastnametxt.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastnametxt.ForeColor = System.Drawing.Color.White;
            this.lastnametxt.Location = new System.Drawing.Point(348, 233);
            this.lastnametxt.Name = "lastnametxt";
            this.lastnametxt.ReadOnly = true;
            this.lastnametxt.Size = new System.Drawing.Size(288, 28);
            this.lastnametxt.TabIndex = 26;
            this.lastnametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(201, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 26);
            this.label2.TabIndex = 25;
            this.label2.Text = "First Name:";
            // 
            // firstnametxt
            // 
            this.firstnametxt.BackColor = System.Drawing.Color.Black;
            this.firstnametxt.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnametxt.ForeColor = System.Drawing.Color.White;
            this.firstnametxt.Location = new System.Drawing.Point(348, 190);
            this.firstnametxt.Name = "firstnametxt";
            this.firstnametxt.ReadOnly = true;
            this.firstnametxt.Size = new System.Drawing.Size(288, 28);
            this.firstnametxt.TabIndex = 24;
            this.firstnametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(206, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "Username:";
            // 
            // usernametxt
            // 
            this.usernametxt.BackColor = System.Drawing.Color.Black;
            this.usernametxt.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametxt.ForeColor = System.Drawing.Color.White;
            this.usernametxt.Location = new System.Drawing.Point(348, 276);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.ReadOnly = true;
            this.usernametxt.Size = new System.Drawing.Size(288, 28);
            this.usernametxt.TabIndex = 22;
            this.usernametxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // f_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MSF.Properties.Resources.Stars;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.lastnametxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstnametxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_Profile";
            this.Text = "f_Profle";
            this.Load += new System.EventHandler(this.f_Profile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label lastname;
        private System.Windows.Forms.TextBox lastnametxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstnametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernametxt;
    }
}