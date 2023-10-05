namespace MSF
{
    partial class f_SubMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_SubMenu));
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.playGame = new System.Windows.Forms.Button();
            this.ViewProfile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(183, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 52);
            this.label1.TabIndex = 10;
            this.label1.Text = "MARIO\'S SPACE FORCE";
            // 
            // playGame
            // 
            this.playGame.BackColor = System.Drawing.Color.Black;
            this.playGame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.playGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.playGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playGame.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playGame.ForeColor = System.Drawing.Color.White;
            this.playGame.Location = new System.Drawing.Point(122, 331);
            this.playGame.Name = "playGame";
            this.playGame.Size = new System.Drawing.Size(254, 31);
            this.playGame.TabIndex = 11;
            this.playGame.Text = "Play Game";
            this.playGame.UseVisualStyleBackColor = false;
            this.playGame.Click += new System.EventHandler(this.playGame_Click);
            // 
            // ViewProfile
            // 
            this.ViewProfile.BackColor = System.Drawing.Color.Black;
            this.ViewProfile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ViewProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.ViewProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewProfile.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewProfile.ForeColor = System.Drawing.Color.White;
            this.ViewProfile.Location = new System.Drawing.Point(454, 331);
            this.ViewProfile.Name = "ViewProfile";
            this.ViewProfile.Size = new System.Drawing.Size(254, 31);
            this.ViewProfile.TabIndex = 12;
            this.ViewProfile.Text = "View Profile";
            this.ViewProfile.UseVisualStyleBackColor = false;
            this.ViewProfile.Click += new System.EventHandler(this.ViewProfile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Logged In As:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(93, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "0";
            // 
            // f_SubMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MSF.Properties.Resources.Stars;
            this.ClientSize = new System.Drawing.Size(850, 600);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ViewProfile);
            this.Controls.Add(this.playGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_SubMenu";
            this.Text = "f_SubMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button playGame;
        private System.Windows.Forms.Button ViewProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}