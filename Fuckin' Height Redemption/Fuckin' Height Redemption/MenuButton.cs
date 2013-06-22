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
    public class MenuButton
    {
        public MenuButton(Vector2 position, Texture2D texturefr, Texture2D textureen, Texture2D textureit, Texture2D texturede, bool couleurachanger)
        {

            this.position = position;
            this.texturefr = texturefr;
            this.textureen = textureen;
            this.textureit = textureit;
            this.texturede = texturede;
            this.rectangle = GetRectangle();
            this.couleurachanger = couleurachanger;
        }

        private Vector2 position;
        private Texture2D texturefr;
        private Texture2D textureen;
        private Texture2D textureit;
        private Texture2D texturede;
        private Rectangle rectangle;
        private bool couleurachanger;

        /// <summary>
        /// Defini la position
        /// </summary>
        /// <param name="position"></param>
        public void SetPosition(Vector2 position)
        {
            this.position = position;
            rectangle = GetRectangle();
        }

        /// <summary>
        /// retourne la position
        /// </summary>
        /// <returns></returns>
        public Vector2 GetPosition()
        {
            return position;
        }

        /// <summary>
        /// renvoie le rectangle
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, texturefr.Width, texturefr.Height);
            return rectangle;
        }

        /// <summary>
        /// renvoie la texture francaise
        /// </summary>
        /// <returns></returns>
        public Texture2D GetTexturefr()
        {
            return texturefr;
        }

        /// <summary>
        /// renvoie la texture anglaise
        /// </summary>
        /// <returns></returns>
        public Texture2D GetTextureen()
        {
            return textureen;
        }

        /// <summary>
        /// renvoie la texture italienne
        /// </summary>
        /// <returns></returns>
        public Texture2D GetTextureit()
        {
            return textureit;
        }

        public Texture2D GetTexturede()
        {
            return texturede;
        }

        /// <summary>
        /// dessine le bouton
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="lang"></param>
        public void DrawButton(SpriteBatch spriteBatch, int lang, bool touche)
        {

            if (touche)
            {
                if (this.couleurachanger)
                {
                    if (lang == 1)
                        spriteBatch.Draw(texturefr, position, Color.Salmon);
                    if (lang == 2)
                        spriteBatch.Draw(textureen, position, Color.Salmon);
                    if (lang == 3)
                        spriteBatch.Draw(textureit, position, Color.Salmon);
                    if (lang == 4)
                        spriteBatch.Draw(texturede, position, Color.Salmon);
                }
                else
                {
                    if (lang == 1)
                        spriteBatch.Draw(texturefr, position, Color.DarkOrange);
                    if (lang == 2)
                        spriteBatch.Draw(textureen, position, Color.DarkOrange);
                    if (lang == 3)
                        spriteBatch.Draw(textureit, position, Color.DarkOrange);
                    if (lang == 4)
                        spriteBatch.Draw(texturede, position, Color.DarkOrange);
                }
            }
            else
            {
                if (lang == 1)
                    spriteBatch.Draw(texturefr, position, Color.White);
                if (lang == 2)
                    spriteBatch.Draw(textureen, position, Color.White);
                if (lang == 3)
                    spriteBatch.Draw(textureit, position, Color.White);
                if (lang == 4)
                    spriteBatch.Draw(texturede, position, Color.White);
            }



        }


    } // end class
}
