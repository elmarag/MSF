using System;
using System.Drawing;
using System.Collections;

namespace MSF
{
    public class CShields : CGameObject
    {
		private ArrayList BulletImpact = new ArrayList(50);
		public CShields() : base("shield.gif")
		{
			
		}

		public override void DrawElement(Graphics g)
		{
			base.DrawElement(g);
			foreach (Rectangle r in BulletImpact)
			{
				g.FillRectangle(Brushes.Black, r);
			}
		}

		public void CreateBulletHole(Rectangle r, bool dir)
		{
			Rectangle rup = r;
			rup.Inflate(r.Width / 4, -r.Height / 4);

			if (dir == true)
			{
				rup.Offset(0, -r.Height / 2);
			}
			else
			{
				//			rup.Offset(0, r.Height/2);
				rup.Height += 20;

				// make sure the whole top part of the shield is clear
				if ((rup.Y - gameObject_Position.Y) <= 20)
				{
					rup.Y = gameObject_Position.Y;
					rup.Height += 5;
				}
			}

			BulletImpact.Add(rup);
		}

		private bool CheckBulletImpactIntersection(Rectangle rTest, bool dirDown)
		{
			Rectangle rTest1 = rTest;

			// thin out bullet for test
			rTest1.X += rTest1.Width / 2;
			rTest1.Width = 3;

			foreach (Rectangle r in BulletImpact)
			{
				if (rTest1.IntersectsWith(r))
				{
					return true;
				}
			}

			return false;
		}

		public bool TestCollision(Rectangle r, bool directionDown, out bool bulletHole)
		{
			bulletHole = false;

			if (CheckBulletImpactIntersection(r, directionDown))
			{
				bulletHole = true;
				return false;  // doesn't count as a collision
			}

			if (r.IntersectsWith(gameObject_MovingBounds))
			{
				CreateBulletHole(r, directionDown);
				return true;
			}

			return false;
		}
	}
}
