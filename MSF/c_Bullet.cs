using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF
{
	public class CBullet : CGameObject //creating the bullets shot - inherits from CGameObject
	{
		const int __interval = 15;
		public int BulletInterval = __interval;

		public CBullet(int x, int y) //calls first version of constructor 
		{
			gameObject_ImageBounds.Width = 5; //set its dimensions
			gameObject_ImageBounds.Height = 15;
			gameObject_Position.X = x; //set its position
			gameObject_Position.Y = y;
		}

		public void ResetBulletPosition()
		{
			if (f_Level1.ActiveForm != null) //if the form isn't null 
			{
				gameObject_Position.Y = f_Level1.ActiveForm.ClientRectangle.Bottom; //set it at the bottom of the active form
				gameObject_MovingBounds.Y = gameObject_Position.Y; 
			}

			BulletInterval = __interval;
		}


		public override void DrawElement(Graphics graphics) //draw the bullet and set its position
		{
			UpdateGameBounds();
			graphics.FillRectangle(Brushes.Orange, gameObject_MovingBounds);
			gameObject_Position.Y -= BulletInterval;
		}

	}
}
