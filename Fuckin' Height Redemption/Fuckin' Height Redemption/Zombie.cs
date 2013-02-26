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
    class Zombie
    {
        public Zombie(Vector2 position, float speed, Texture2D texture0, Texture2D texture45, Texture2D texture90, Texture2D texture135, Texture2D texture180, Texture2D texture225, Texture2D texture270, Texture2D texture315)
        {
            this.texture0 = texture0;
            this.texture45 = texture45;
            this.texture90 = texture90;
            this.texture135 = texture135;
            this.texture180 = texture180;
            this.texture225 = texture225;
            this.texture270 = texture270;
            this.texture315 = texture315;
            this.position = position;
            this.speed = speed; 
            SetRectangle();
        }

        private float speed;
        private float anglevisee;

        private Vector2 position;
        private Vector2 direction;
        private Vector2 visee;

        private Rectangle rectangle;

        private Texture2D texture0;
        private Texture2D texture45;
        private Texture2D texture90;
        private Texture2D texture135;
        private Texture2D texture180;
        private Texture2D texture225;
        private Texture2D texture270;
        private Texture2D texture315;



        public void Move(Joueur joueur, int height, int width)
        {
            direction = (joueur.GetPosition() - position)/(joueur.GetPosition() - position).Length();

            if (!rectangle.Intersects(joueur.GetTarget()))
            {
                SetPosition(position + (direction * speed));
            }

            /*if (position.Y + texture0.Height >= height)
                position.Y = height - texture0.Height;
            else
                if (position.Y <= 0)
                    position.Y = 0;

            if (position.X + texture0.Width >= width)
                position.X = width - texture0.Width;
            else
                if (position.X <= 0)
                    position.X = 0;*/
            SetRectangle();
        }



        public void DrawZombie(SpriteBatch spriteBatch, bool iso2D)
        {
            if (iso2D)
            {
                spriteBatch.Draw(GetTexture(), new Rectangle(GetRectangle().X + GetRectangle().Width / 2, GetRectangle().Y + GetRectangle().Height / 2, GetRectangle().Width, GetRectangle().Height), null, Color.White, GetAngleVisee(), new Vector2(GetTexture().Width / 2, GetTexture().Height / 2), SpriteEffects.None, 0f);
            }
            else
            {
                if (GetAngleViseeDeg() >= -23 && GetAngleViseeDeg() <= 24)
                    spriteBatch.Draw(texture0, rectangle, Color.White);

                if (GetAngleViseeDeg() >= 24 && GetAngleViseeDeg() <= 68)
                    spriteBatch.Draw(texture45, rectangle, Color.White);

                if (GetAngleViseeDeg() >= 68 && GetAngleViseeDeg() <= 114)
                    spriteBatch.Draw(texture90, rectangle, Color.White);

                if (GetAngleViseeDeg() >= 114 && GetAngleViseeDeg() <= 158)
                    spriteBatch.Draw(texture135, rectangle, Color.White);

                if ((GetAngleViseeDeg() >= 158 && GetAngleViseeDeg() <= 180) || (GetAngleViseeDeg() >= -180 && GetAngleViseeDeg() <= -158))
                    spriteBatch.Draw(texture180, rectangle, Color.White);

                if (GetAngleViseeDeg() >= -158 && GetAngleViseeDeg() <= -114)
                    spriteBatch.Draw(texture225, rectangle, Color.White);

                if (GetAngleViseeDeg() >= -114 && GetAngleViseeDeg() <= -68)
                    spriteBatch.Draw(texture270, rectangle, Color.White);

                if (GetAngleViseeDeg() >= -68 && GetAngleViseeDeg() <= -23)
                    spriteBatch.Draw(texture315, rectangle, Color.White);
            }
        }



        public static Zombie SpawnZombie(int width, int height, ContentManager Content)
        {
            Random random = new Random();
            float decimalspeed = (float)random.Next(0, 6);
            float zombiespeed = 1 + (decimalspeed / 10);

            Vector2 pop_position = new Vector2();

            int border = random.Next(0, 4); // determine d'ou va arriver le zombie 0,1,2,3 => haut,bas,gauche,droite

            if (border == 0)
            {
                pop_position.Y = -100;
                pop_position.X = random.Next(0, width);
            }
            if (border == 1)
            {
                pop_position.Y = height + 100;
                pop_position.X = random.Next(0, width);
            }
            if (border == 2)
            {
                pop_position.X = -100;
                pop_position.Y = random.Next(0, height);
            }
            if (border == 3)
            {
                pop_position.X = width + 100;
                pop_position.Y = random.Next(0, height);
            }

            return new Zombie(pop_position, zombiespeed, Content.Load<Texture2D>("Zombie 0"), Content.Load<Texture2D>("Zombie 45"), Content.Load<Texture2D>("Zombie 90"), Content.Load<Texture2D>("Zombie 135"), Content.Load<Texture2D>("Zombie 180"), Content.Load<Texture2D>("Zombie 225"), Content.Load<Texture2D>("Zombie 270"), Content.Load<Texture2D>("Zombie 315"));

        }










        public void SetVisee()
        {
            visee = new Vector2((float)Math.Cos(anglevisee), (float)Math.Sin(anglevisee));
        }

        public Vector2 GetVisee()
        {
            return visee;
        }


        public void SetAngleVisee(Vector2 joueur_position)
        {
            Vector2 angle;
            angle.X = joueur_position.X - rectangle.Center.X;
            angle.Y = joueur_position.Y - rectangle.Center.Y;

            double rad = Math.Atan2(angle.Y, angle.X);
            anglevisee = (float)rad;
        }

        public float GetAngleVisee()
        {
            return anglevisee;
        }

        public float GetAngleViseeDeg()
        {
            return -MathHelper.ToDegrees(anglevisee);
        }


        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }



        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }



        public Vector2 GetDirection()
        {
            return direction;
        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }



        public Rectangle GetRectangle()
        {
            return rectangle;
        }

        public void SetRectangle()
        {
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)(texture0.Width / 1.5), (int)(texture0.Height / 1.5));
        }

        public Vector2 GetRectangleCenter()
        {
            return new Vector2(rectangle.Center.X, rectangle.Center.Y);
        }


        public Texture2D GetTexture()
        {
            return texture0;
        }


        

    } // End Class
}
