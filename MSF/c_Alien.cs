using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MSF
{
	//CAlien description
	public class CAlien : CGameObject	
	{
		private Image oImange = null;

		private const int bombDist = 250;

		private CBomb oBomb = new CBomb(0, 0);

		private bool bombActive = false;

		public bool isHit = false;

		public int explosionCounter = 0;

		public bool isDead = false;

		private int rseed = (int)DateTime.Now.Ticks;
		private Random randNum = null;


		public bool MoveRight = true;

		private const int kInterval = 10;
		private long Counter = 0;

		public CAlien(string i1, string i2) : base(i1)
		{
			oImange = Image.FromFile(i2);

			randNum = new Random(rseed);

			gameObject_Position.X = 20;
			gameObject_Position.Y = 10;
			UpdateGameBounds();
		}

		public override void DrawElement(Graphics g)
		{
			UpdateGameBounds();

			if (isHit)
			{
				DrawExplosion(g);
				return;
			}

			if (Counter % 2 == 0)
				g.DrawImage(gameObject_Image, gameObject_MovingBounds, 0, 0, gameObject_ImageBounds.Width, gameObject_ImageBounds.Height, GraphicsUnit.Pixel);
			else
				g.DrawImage(oImange, gameObject_MovingBounds, 0, 0, gameObject_ImageBounds.Width, gameObject_ImageBounds.Height, GraphicsUnit.Pixel);

			if (bombActive)
			{
				oBomb.DrawElement(g);
				if (f_Level1.ActiveForm != null)
				{
					if (oBomb.gameObject_Position.Y > f_Level1.ActiveForm.ClientRectangle.Height)
					{
						bombActive = false;
					}
				}
			}


			if ((bombActive == false) && (Counter % bombDist == 0))
			{
				bombActive = true;
				oBomb.gameObject_Position.X = gameObject_MovingBounds.X + gameObject_MovingBounds.Width / 2;
				oBomb.gameObject_Position.Y = gameObject_Position.Y + 5;
			}

		}

		public void ResetBombPosition()
		{
			oBomb.gameObject_Position.X = gameObject_Position.X + gameObject_MovingBounds.Width / 2;
			oBomb.ResetBombCharacteristics(gameObject_MovingBounds.Y + 5);
		}

		public void SetCounter(long lCount)
		{
			Counter = lCount;
		}

		public void DrawExplosion(Graphics g)
		{

			if (isDead)
				return;

			explosionCounter++;
			if (explosionCounter < 15)
			{
				for (int i = 0; i < 50; i++)
				{
					int xval = randNum.Next(gameObject_MovingBounds.Width);
					int yval = randNum.Next(gameObject_MovingBounds.Height);
					xval += gameObject_Position.X;
					yval += gameObject_Position.Y;
					g.DrawLine(Pens.White, xval, yval, xval, yval + 1);
				}
			}
			else
			{
				isDead = true;
			}
		}

		public void Move()
		{
			if (isHit)
				return;

			if (MoveRight)
			{
				gameObject_Position.X += kInterval;
			}
			else
			{
				gameObject_Position.X -= kInterval;
			}

			Counter++;
		}

		public void MoveInPlace()
		{
			Counter++;
		}

		public Rectangle GetBombBounds()
		{
			return oBomb.GetImageBounds();
		}

		public bool IsBombColliding(Rectangle r)
		{
			if (bombActive && oBomb.GetImageBounds().IntersectsWith(r))
			{
				return true;
			}

			return false;
		}

	}
}
