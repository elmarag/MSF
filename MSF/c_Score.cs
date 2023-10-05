using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MSF
{
	public class CScore
	{
		public int CountScore = 0;
		public Point ScorePosition = new Point(0, 0);
		public Font ScoreFont = new Font("Compact", 24.0f, GraphicsUnit.Pixel);

		public CScore(int x, int y)
		{
			ScorePosition.X = x;
			ScorePosition.Y = y;
		}


		public bool IsGameOver = false;

		public virtual void Draw(Graphics g) //Draws the score to the Rectangle frame
		{
			if (IsGameOver == false)
				g.DrawString("Score: " + CountScore.ToString(), ScoreFont, Brushes.LimeGreen, ScorePosition.X, ScorePosition.Y, new StringFormat());
			else
				g.DrawString("Game Over - Final Score: " + CountScore.ToString(), ScoreFont, Brushes.White, ScorePosition.X, ScorePosition.Y + ScoreFont.Height -25, new StringFormat());

		}

		public Rectangle GetScoreFrame() //sets the position and size of the frame to the form
		{
			Rectangle scoreRectangle = new Rectangle(ScorePosition.X, ScorePosition.Y, (int)ScoreFont.SizeInPoints * CountScore.ToString().Length, ScoreFont.Height);
			return scoreRectangle;
		}


		//Resets the score to 0
		public void ResetPlayerScore()
		{
			CountScore = 0;
		}

		//Increments score by 1
		public void IncrementPlayerScore()
		{
			CountScore++;
		}

		//Adds according to the mushroom score
		public void AddPlayerScore(int val)
		{
			CountScore += val;
		}

		public void WriteFile(int currentScore)
		{
			ReadFile();
				CountScore = currentScore;
				StreamWriter sw = new StreamWriter("score.txt", false);
				sw.WriteLine(CountScore.ToString());
				sw.Close();
		}


		public void ReadFile()
		{
			if (File.Exists("score.txt"))
			{
				StreamReader sr = new StreamReader("score.txt");
				string score = sr.ReadLine();
				CountScore = Convert.ToInt32(score);
				sr.Close();
			}
		}
	}
}
