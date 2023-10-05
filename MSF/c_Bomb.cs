using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF
{
    public class CBomb: CGameObject //class for the creation of the bombs shot by the aliens - inherits from CGameObject
    {
        public const int ShootingConst= 5; //variables that define the shooting interval of the bombs
        public int BombInterval = ShootingConst;
        Pen BombPen;

        public CBomb(int x, int y) //constructor
        {
            gameObject_ImageBounds.Width = 5;
            gameObject_ImageBounds.Height = 15;
            gameObject_Position.X = x;
            gameObject_Position.Y = y;
            CreateWayInPath();
            CreateWayOutPath();

            BombPen = new Pen(Color.White, 2); //visualizing it with the Pen class
            BombPen.DashStyle = DashStyle.DashDot;

        }

        GraphicsPath BombWayIn = new GraphicsPath(); //two graphic paths that will serve as a series of connected lines and curves
        GraphicsPath BombWayOut = new GraphicsPath();
        GraphicsPath BombWayInTransformed = new GraphicsPath(); //two graphics paths for the transformation visualization of the bomb
        GraphicsPath BombWayOutTransformed = new GraphicsPath();

        void CreateWayInPath() //appending a line segment to the GraphicsPath.
        {
            float width = 5;
            float height = 15;
            float seg = height / 3;
            BombWayIn.AddLine(new PointF(0, 0), new PointF(width, seg)); //setting several markers in the path with start and end points
            BombWayIn.AddLine(new PointF(width, seg), new PointF(0, seg * 2));
            BombWayIn.AddLine(new PointF(0, seg * 2), new PointF(width, seg * 3));
        }

        void CreateWayOutPath()
        {
            float width = 5;
            float height = 15;
            float seg = height / 3;
            BombWayOut.AddLine(new PointF(width, 0), new PointF(0, seg));
            BombWayOut.AddLine(new PointF(0, seg), new PointF(width, seg * 2));
            BombWayOut.AddLine(new PointF(width, seg * 2), new PointF(0, seg * 3));
        }


        bool IsItInvertable = false; //if the matrix is invertible
		public override void DrawElement(Graphics g) //toggling the bomb in and bomb out graphics paths to give it the spinning effect
        {
            UpdateGameBounds();
            Matrix m = new Matrix(); //matrix for composite transformation to make it look like it is spinning

            m.Translate(gameObject_MovingBounds.Left, gameObject_MovingBounds.Top); //translating the matrix in accordance to the coordinates that are 
                                                                                    //being constantly updated

            if (IsItInvertable)
            {

                BombWayInTransformed = (GraphicsPath)BombWayIn.Clone(); //cloning the graphics path
                BombWayInTransformed.Transform(m); //transforming the path of the graph
                g.DrawPath(BombPen, BombWayInTransformed); //draw it to the screen
                BombWayInTransformed.Dispose(); //ending it
            }
            else
            {
                BombWayOutTransformed = (GraphicsPath)BombWayOut.Clone();
                BombWayOutTransformed.Transform(m);
                g.DrawPath(BombPen, BombWayOutTransformed);
                BombWayOutTransformed.Dispose();
            }

            IsItInvertable = !IsItInvertable; //switching


            gameObject_Position.Y += BombInterval; //changing the position of the bullet every interval
        }

        public void ResetBombCharacteristics(int yPos) //resetting its Y position after being shot
        {
            gameObject_Position.Y = yPos;
            BombInterval = ShootingConst;
            UpdateGameBounds();
        }


    }
}
