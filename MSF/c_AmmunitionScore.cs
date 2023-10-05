using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MSF
{
    public class CAmmunitionScore : CScore
    {

        public CAmmunitionScore(int x, int y) : base(x, y)
        {

        }

        public int DecrementPlayerScore()
        {
            CountScore = CountScore - 11;
			return CountScore;
		}

		public void WriteFile(int currentScore)
		{
				StreamWriter sw = new StreamWriter("ammoscore.txt", false);
				sw.WriteLine(CountScore.ToString());
				sw.Close();
		}


		public void ReadFile()
		{
			if (File.Exists("ammoscore.txt"))
			{
				StreamReader sr = new StreamReader("ammoscore.txt");
				string score = sr.ReadLine();
				CountScore = Convert.ToInt32(score);
				sr.Close();
			}
		}

		public override void Draw(Graphics g) //Draws the score to the Rectangle frame
        {
            g.DrawString("Ammunition Score: " + CountScore.ToString(), ScoreFont, Brushes.LimeGreen, ScorePosition.X, ScorePosition.Y, new StringFormat());
        }
    }
}
