using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MSF
{
    public class CLifeIndicator : CGameObject
    {
        public int NoOfLives = 4;
        Font LivesFont = new Font("Compact", 20.0f);

        public CLifeIndicator(int x, int y) : base("man.gif")
        {
            this.gameObject_Position = new Point(x, y);
        }

        public void DecrementLives()
        {
            NoOfLives--;
        }

        public override void DrawElement(System.Drawing.Graphics g)
        {
            g.DrawString("Lives", LivesFont, Brushes.White, gameObject_Position);

            if (NoOfLives > 0)
            {
                g.DrawImage(gameObject_Image, gameObject_Position.X + 80, gameObject_Position.Y, gameObject_Image.Width * 2 / 3, gameObject_Image.Height * 2 / 3);
            }

            if (NoOfLives > 1)
            {
                g.DrawImage(gameObject_Image, gameObject_Position.X + 80 + gameObject_Image.Width * 2 / 3, gameObject_Position.Y, gameObject_Image.Width * 2 / 3, gameObject_Image.Height * 2 / 3);
            }

            if (NoOfLives > 2)
            {
                g.DrawImage(gameObject_Image, gameObject_Position.X + 80 + 2 * gameObject_Image.Width * 2 / 3, gameObject_Position.Y, gameObject_Image.Width * 2 / 3, gameObject_Image.Height * 2 / 3);
            }

            if (NoOfLives > 3)
            {
                g.DrawImage(gameObject_Image, gameObject_Position.X + 120 + 2 * gameObject_Image.Width * 2 / 3, gameObject_Position.Y, gameObject_Image.Width * 2 / 3, gameObject_Image.Height * 2 / 3);
            }
        }
    }
}
