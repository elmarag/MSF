using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSF
{
    public class CGameObject  //container class for all game objects
    {
        protected Image gameObject_Image = null; //image class to create the image of the game object
        public Point gameObject_Position = new Point(50, 50); //pair of x and y coordinates to define a point in the two-dimensional plane.
        protected Rectangle gameObject_ImageBounds = new Rectangle(0, 0, 10, 10); //the location and size of a rectangle image
        protected Rectangle gameObject_MovingBounds = new Rectangle(); //moving image's rectangle object whose values are to be set

        public CGameObject() //constructor set the object's image to null
        {
            gameObject_Image = null;
        }

        public CGameObject(string imageName) //overloaded constructor - specifies the image's file name
        {
            gameObject_Image = Image.FromFile(imageName);
            gameObject_ImageBounds.Width = gameObject_Image.Width;
            gameObject_ImageBounds.Height = gameObject_Image.Height;
        }

        public Image GetGameObjectImage() //return the game object image
        {
            return gameObject_Image;
        }

        public int ImageWidth //property width of the game object image
        {
            get
            {
                return gameObject_ImageBounds.Width;
            }
        }

        public int ImageHeight //property height of the game object image
        {
            get
            {
                return gameObject_ImageBounds.Height;
            }
        }


        public virtual int GetImageWidth() //virtual method to retrieve the width of the game object image
        {
            return gameObject_ImageBounds.Width;
        }


        public virtual Rectangle GetImageBounds() //virtual method to get the bounds of the moving image
        {
            return gameObject_MovingBounds;
        }

        public void UpdateGameBounds() //updating the size and position of the rectangle moving image bounds
        {
            gameObject_MovingBounds = gameObject_ImageBounds;
            gameObject_MovingBounds.Offset(gameObject_Position);
        }


        public virtual void DrawElement(Graphics graphic) //Draws the specified portion of the specified Image 
                                                          //at the specified location and with the specified size.
        {
            UpdateGameBounds();
            graphic.DrawImage(gameObject_Image, gameObject_MovingBounds, 0, 0, gameObject_ImageBounds.Width, gameObject_ImageBounds.Height, GraphicsUnit.Pixel);
        }

    }
}
