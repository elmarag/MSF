using System;
using System.Drawing;

namespace MSF
{
    public class CAlienRows
    {
		public CAlien[] Aliens = new CAlien[11];
		public Point LastPosition = new Point(0, 0);
		public const int kBombIntervalSpacing = 50;


		public CAlienRows(string gif1, string gif2, int rowNum, int Pos)
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				Aliens[i] = new CAlien(gif1, gif2);
				Aliens[i].gameObject_Position.X = i * Aliens[i].GetImageBounds().Width + 5;
				Aliens[i].gameObject_Position.Y = rowNum * Aliens[i].GetImageBounds().Height + Pos;
				Aliens[i].SetCounter(i * kBombIntervalSpacing);
			}

			LastPosition = Aliens[Aliens.Length - 1].gameObject_Position;
		}

		public void ResetBombCounters()
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				Aliens[i].ResetBombPosition();
				Aliens[i].SetCounter(i * kBombIntervalSpacing);
			}
		}

		public CAlien this[int index]   // indexer declaration
		{
			get
			{
				return Aliens[index];
			}
		}


		public void Draw(Graphics g)
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				Aliens[i].DrawElement(g);
			}
		}

		public int CollisionTest(Rectangle aRect)
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				if ((Aliens[i].GetImageBounds().IntersectsWith(aRect)) && (!Aliens[i].isHit))
					return i;
			}

			return -1;
		}

		public bool DirectionRight
		{
			set
			{
				for (int i = 0; i < Aliens.Length; i++)
				{
					Aliens[i].MoveRight = value;
				}
			}
		}

		public void Move()
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				Aliens[i].Move();
			}

			if (Aliens[0].MoveRight)
				LastPosition = Aliens[Aliens.Length - 1].gameObject_Position;
			else
				LastPosition = Aliens[0].gameObject_Position;

		}

		public void MoveOnSpot()
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				Aliens[i].MoveInPlace();
			}

		}


		public CAlien FirstAlien()
		{
			int count = 0;
			CAlien TheAlien = Aliens[count];
			while ((TheAlien.isHit == true) && (count < Aliens.Length - 1))
			{
				count++;
				TheAlien = Aliens[count];
			}

			return TheAlien;
		}

		public CAlien GetLastInvader()
		{
			int count = Aliens.Length - 1;
			CAlien TheInvader = Aliens[count];
			while ((TheInvader.isHit == true) && (count > 0))
			{
				count--;
				TheInvader = Aliens[count];
			}

			return TheInvader;
		}

		public int NumberOfLiveInvaders()
		{
			int count = 0;
			for (int i = 0; i < Aliens.Length; i++)
			{
				if (Aliens[i].isDead == false)
					count++;
			}

			return count;
		}

		public bool AlienHasLanded(int bottom)
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				if ((Aliens[i].GetImageBounds().Bottom >= bottom) &&
					 (Aliens[i].isHit = false))
					return true;
			}

			return false;

		}

		public void MoveDown()
		{
			for (int i = 0; i < Aliens.Length; i++)
			{
				Aliens[i].gameObject_Position.Y += Aliens[i].GetImageBounds().Height / 8;
				Aliens[i].UpdateGameBounds();
			}
		}


	}
}
