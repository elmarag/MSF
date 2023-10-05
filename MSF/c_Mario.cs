using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF
{
    public class CMario: CGameObject //Creating Mario - inherits from CGameObject
    {
		private int __moveInterval = 5; //interval that will determine the moving space of Mario across screen
		public bool IsDead = false;
		public bool IsHit = false;
		public int ExplosionCount = 0;

		public CMario() : base("man.gif") //constructor that sets the image's file name
		{
			gameObject_Position.X = 200; //sets x and y coordinates
			gameObject_Position.Y = 400;

		}

		public void MoveLeft() //calculating Mario's left and right movement
		{
			gameObject_Position.X -= __moveInterval; //if it moves to the left reduce the X coordinate with the interval
			if (gameObject_Position.X < 0) //when it is lower than 0 set it to 0 to avoid out of the screen movement
				gameObject_Position.X = 0;
		}

		public void MoveRight(int nLimit)
		{
			gameObject_Position.X += __moveInterval; //if it moves to the right add the interval to the X coordinate
			if (gameObject_Position.X > nLimit - ImageWidth) //limit the movement to the right 
				gameObject_Position.X = nLimit - ImageWidth;
		}

		public Point BulletStartPosition() //setting the position of the bullet the character shoots to the middle of the character
		{								//so that it stays in the middle even when it is moving
			Point StartingPoint = new Point(
				gameObject_MovingBounds.Left + gameObject_MovingBounds.Width / 2,
				gameObject_MovingBounds.Top - 10);

			return StartingPoint;
		}


		Random RandomNumber = new Random((int)DateTime.Now.Ticks); //get random integers - 1 tick = 100 nano seconds
		public void MariosExplosion(Graphics graphics)
		{
			ExplosionCount++;
			if (ExplosionCount < 15)
			{
				for (int i = 0; i < 50; i++)
				{
					int Xvalue = RandomNumber.Next(gameObject_MovingBounds.Width); //get a random value smaller than the width of the moving object's image
					int Yvalue = RandomNumber.Next(gameObject_MovingBounds.Height); //get a random value smaller than the height of the moving object's image
					Xvalue += gameObject_Position.X; //add to it, the coordinate of the existing position of the object
					Yvalue += gameObject_Position.Y;
					graphics.DrawLine(Pens.Chartreuse, Xvalue, Yvalue, Xvalue, Yvalue + 1); //visualize the explosion by connecting two pairs of coordinates
				}
			}
		}


		public override void DrawElement(Graphics graphics) //visualize Mario
		{
			if (IsDead) //if dead do not visualize
				return;

			if (IsHit == false) //if it hasn't been hit visualize him
			{
				base.DrawElement(graphics);
			}
			else
			{
				if (ExplosionCount < 15) //if it has been hit visualize his explosion
					MariosExplosion(graphics);
				else
					IsDead = true;
			}
		}

		public void Reset() //resetting the character after it has died
		{
			IsHit = false;
			IsDead = false;
			ExplosionCount = 0;
		}

	}
}
