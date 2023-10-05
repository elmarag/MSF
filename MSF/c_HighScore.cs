using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF
{
	public class CHighScore : CScore
	{
		public CHighScore(int x, int y) : base(x, y)
		{
		}

		public override void Draw(Graphics g)
		{
			g.DrawString("Highest Score: " + CountScore.ToString(), ScoreFont, Brushes.LimeGreen, ScorePosition.X, ScorePosition.Y, new StringFormat());
		}

		public void WriteFile(int currentScore)
		{
			ReadFile();
			if (CountScore < currentScore)
			{
				CountScore = currentScore;
				StreamWriter sw = new StreamWriter("highestscore.txt", false);
				sw.WriteLine(CountScore.ToString());
				sw.Close();
			}
		}


		public void ReadFile()
		{
			if (File.Exists("highestscore.txt"))
			{
				StreamReader sr = new StreamReader("highestscore.txt");
				string score = sr.ReadLine();
				CountScore = Convert.ToInt32(score);
				sr.Close();
			}
		}
	}
}
