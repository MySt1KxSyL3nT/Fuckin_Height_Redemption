﻿using System;
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
    class Zombie : IComparable
    {
        public Zombie(Vector2 position, float speed, Texture2D texture2d, Texture2D texture0, Texture2D texture45, Texture2D texture90, Texture2D texture135, Texture2D texture180, Texture2D texture225, Texture2D texture270, Texture2D texture315)
        {
            this.texture2d = texture2d;
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
            this.health = 100;
            this.dead = false;
            SetRectangle();
        }

        int attack_cooldown;

        private float speed;
        private float anglevisee;

        private int health;
        private bool dead;

        private Vector2 position;
        private Vector2 direction;
        private Vector2 visee;

        private Rectangle rectangle;

        private Texture2D texture2d;
        private Texture2D texture0;
        private Texture2D texture45;
        private Texture2D texture90;
        private Texture2D texture135;
        private Texture2D texture180;
        private Texture2D texture225;
        private Texture2D texture270;
        private Texture2D texture315;

        //NE PAS TOUCHER !!
        public override bool Equals(object obj)
        {
            Zombie z = obj as Zombie;
            if (z == null)
                return false;
            return position.Y == z.GetPosition().Y;
        }
        //NE PAS TOUCHER !!
        public override int GetHashCode()
        {
            return position.Y.GetHashCode();
        }
        //NE PAS TOUCHER !!
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            Zombie z = obj as Zombie;

            if (z != null)
                return this.position.Y.CompareTo(z.GetPosition().Y);
            else
                throw new ArgumentException("Not a Zombie");
        }




        public void Move(Joueur joueur, List<Zombie> zombies, int elapsed_time, int height, int width)
        {
            direction = (new Vector2(joueur.GetTarget().X, joueur.GetTarget().Y) - position) / ((new Vector2(joueur.GetTarget().X, joueur.GetTarget().Y) - position).Length());

             //colission avec zombies
            foreach (Zombie z in zombies)
            {
                if (z != null && !z.GetDead())
                {
                    if (rectangle.Intersects(z.GetRectangle()))
                    {
                        //a gauche
                        if (rectangle.X >= (z.GetRectangle().X - rectangle.Width) && rectangle.X <= (z.GetRectangle().X - rectangle.Width + 5) && direction.X > 0)
                        {
                            direction.X = 0;
                        }
                        //a droite
                        if (rectangle.X <= z.GetRectangle().X + z.GetRectangle().Width && rectangle.X >= z.GetRectangle().X + z.GetRectangle().Width - 5 && direction.X < 0)
                        {
                            direction.X = 0;
                        }
                        //en haut
                        if (rectangle.Y >= (z.GetRectangle().Y - rectangle.Height) && rectangle.Y <= (z.GetRectangle().Y - rectangle.Height + 5) && direction.Y > 0)
                        {
                            direction.Y = 0;
                        }
                        //en bas
                        if (rectangle.Y <= z.GetRectangle().Y + z.GetRectangle().Height && rectangle.Y >= z.GetRectangle().Y + z.GetRectangle().Height - 5 && direction.Y < 0)
                        {
                            direction.Y = 0;
                        }
                    }
                }
            }

            if (!rectangle.Intersects(joueur.GetTarget()))
            {
                SetPosition(position + (direction * speed));
            }
            else
            {
                if (attack_cooldown == 0 || attack_cooldown >= 1000)
                {
                    Attack(joueur);
                    attack_cooldown = 0;
                }
            }
            attack_cooldown += elapsed_time;


            SetRectangle();
        }



        public void Attack(Joueur joueur)
        {
            joueur.Hurt(10);
            attack_cooldown = 0;
            Console.WriteLine("attack");
        }



        public void DrawZombie(SpriteBatch spriteBatch, bool iso2D)
        {
            if (!dead)
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




        public static Zombie SpawnZombie(int width, int height, ContentManager Content, int maxspeed)
        {
            Random random = new Random();
            float decimalspeed = (float)random.Next(0, maxspeed);
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

            return new Zombie(pop_position, zombiespeed, Content.Load<Texture2D>("Zombie 2d"), Content.Load<Texture2D>("Zombie 0"), Content.Load<Texture2D>("Zombie 45"), Content.Load<Texture2D>("Zombie 90"), Content.Load<Texture2D>("Zombie 135"), Content.Load<Texture2D>("Zombie 180"), Content.Load<Texture2D>("Zombie 225"), Content.Load<Texture2D>("Zombie 270"), Content.Load<Texture2D>("Zombie 315"));

        }





        public bool GetDead()
        {
            return dead;
        }

        public void Hurt(int dmg)
        {
            this.health -= dmg;
            if (health <= 0)
                dead = true;
        }

        public int GetHeath()
        {
            return this.health;
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
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)(texture0.Width / 3), (int)(texture0.Height / 3));
        }

        public Vector2 GetRectangleCenter()
        {
            return new Vector2(rectangle.Center.X, rectangle.Center.Y);
        }


        public Texture2D GetTexture()
        {
            return texture0;
        }
        public Texture2D GetTexture2d()
        {
            return texture2d;
        }




    } // End Class
}
