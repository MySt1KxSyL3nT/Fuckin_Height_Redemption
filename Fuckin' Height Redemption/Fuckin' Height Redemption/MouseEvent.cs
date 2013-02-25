using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Design;

namespace Fuckin__Height_Redemption
{
    class MouseEvent
    {

        public MouseEvent()
        {

        }

        private MouseState souris;
        private Rectangle position;

        /// <summary>
        /// update la souris
        /// </summary>
        public void UpdateMouse()
        {
            souris = Mouse.GetState();
        }

        /// <summary>
        /// click ou non
        /// </summary>
        /// <returns></returns>
        public bool LeftClick()
        {
            return souris.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// renvoie le rectangle sur le curseur
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            position = new Rectangle((int)souris.X, (int)souris.Y, 1, 1);
            return position;
        }

        public Vector2 GetPosition()
        {
            return new Vector2(souris.X, souris.Y);
        }


    }
}
