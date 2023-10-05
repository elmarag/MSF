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
    public partial class frmHighestScore : Form
    {
        protected CHighScore TheHighScore = null;

        public frmHighestScore()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(850, 720);
            InitializeScore();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form oForm = new frmEntrance();
            oForm.Show();

        }

        private void InitializeScore()
        {
            TheHighScore = new CHighScore(ClientRectangle.Left + 0, 25);
            TheHighScore.ReadFile();
        }

        private void frmHighestScore_Load(object sender, EventArgs e)
        {
            score.Text = TheHighScore.CountScore.ToString();
        }
    }
}
