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
using System.IO;

namespace Fuckin__Height_Redemption
{
    public class Map
    {
        public Map(int map_number, int height, int width, ContentManager Content)
        {
            this.width = width;
            this.height = height;
            switch (map_number)
            {
                default:
                    {
                        background = Content.Load<Texture2D>("map1");
                        break;
                    }
            }
            position = new Vector2(-width, -height);
            UpdateRectangle(height, width);
            direction = new Vector2();
            vitesse = 0;
        }



        private Vector2 position, direction;
        private int vitesse, height, width;
        private Rectangle rec;
        private Texture2D background;
        private Objet[] objets;



        public void Update(Joueur joueur)
        {
            direction.X = -joueur.GetDirection().X;
            direction.Y = -joueur.GetDirection().Y;
            vitesse = joueur.GetSpeed();

            // bord droit
            if (position.X <= -2 * width - width / 2 + 130 && direction.X < 0)
            {
                direction.X = 0;
            }

            //bord gauche
            if (position.X >= 0 + width / 2 - 130 && direction.X > 0)
            {
                direction.X = 0;
            }
            //bas
            if (position.Y <= -2 * height - height / 2 + 160 && direction.Y < 0)
            {
                direction.Y = 0;
            }
            //haut
            if (position.Y >= 0 + height / 2 - 60 && direction.Y > 0)
            {
                direction.Y = 0;
            }

            position += (direction * vitesse);

            UpdateRectangle(height, width);
        }

        public void Update(Joueur j1, Joueur j2, int winX, int winY)
        {
            direction.X = -j1.GetDirection().X - j2.GetDirection().X;
            direction.Y = -j1.GetDirection().Y - j2.GetDirection().Y;
            vitesse = (j1.GetSpeed() + j2.GetSpeed()) / 4;

            if (j1.GetPosition().X >= position.X + rec.Width && direction.X < 0 || j1.GetPosition().X >= winX && direction.X < 0)
                direction.X = 0;

            position += (direction * vitesse);

            UpdateRectangle(height, width);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, rec, Color.White);
        }




        public Rectangle GetRectangle()
        {
            return rec;
        }

        public void UpdateRectangle(int height, int width)
        {
            rec = new Rectangle((int)position.X, (int)position.Y, 3 * width, 3 * height);
        }

        public Vector2 GetDirection()
        {
            return direction;
        }

        public int GetSpeed()
        {
            return vitesse;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
