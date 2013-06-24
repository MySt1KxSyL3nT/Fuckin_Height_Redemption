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
    public class Zombie : IComparable
    {
        public Zombie(Vector2 position, float speed, Texture2D[,] textures, Texture2D mort)
        {
            this.mort = mort;
            this.textures = textures;
            this.position = position;
            this.speed = speed;
            this.health = 100;
            this.dead = false;
            SetRectangle();
            SetTarget();
            time_since_dead = 0;
        }

        int attack_cooldown;

        private int time_since_dead;

        private float speed;
        private float anglevisee;

        private int health;
        private bool dead;

        private Vector2 position;
        private Vector2 direction;
        private Vector2 visee;

        private Rectangle rectangle;
        private Rectangle target; // pour la colision

        private Texture2D[,] textures;
        private Texture2D mort;

        private int dist_marche;// pour l'animation
        private int pas;// pour la texture a afficher


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
            direction = (new Vector2(joueur.GetRectangle().X, joueur.GetRectangle().Y) - position) / ((new Vector2(joueur.GetRectangle().X, joueur.GetRectangle().Y) - position).Length()) ; //+ (Game1.map.GetDirection() * Game1.map.GetSpeed());

             //colission avec zombies
            foreach (Zombie z in zombies)
            {
                if (z != null && !z.GetDead())
                {
                    if (target.Intersects(z.GetTarget()))
                    {
                        //a gauche
                        if (target.X >= (z.GetTarget().X - rectangle.Width) && target.X <= (z.GetTarget().X - target.Width + 5) && direction.X > 0)
                        {
                            direction.X = 0;
                        }
                        //a droite
                        if (target.X <= z.GetTarget().X + z.GetTarget().Width && target.X >= z.GetTarget().X + z.GetTarget().Width - 5 && direction.X < 0)
                        {
                            direction.X = 0;
                        }
                        //en haut
                        if (target.Y >= (z.GetTarget().Y - target.Height) && target.Y <= (z.GetTarget().Y - target.Height + 5) && direction.Y > 0)
                        {
                            direction.Y = 0;
                        }
                        //en bas
                        if (target.Y <= z.GetTarget().Y + z.GetTarget().Height && target.Y >= z.GetTarget().Y + z.GetTarget().Height - 5 && direction.Y < 0)
                        {
                            direction.Y = 0;
                        }
                    }
                }
            }

            if (!target.Intersects(joueur.GetTarget()))
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
                else
                {
                    SetPosition(position);
                }
            }
            SetPosition(position + (Game1.map.GetDirection() * Game1.map.GetSpeed()));
            attack_cooldown += elapsed_time;


            SetRectangle();
            SetTarget();
        }



        public void Attack(Joueur joueur)
        {
            joueur.Hurt(10);
            attack_cooldown = 0;
        }



        public void DrawZombie(SpriteBatch spriteBatch)
        {
            if (!dead)
            {
                if (GetAngleViseeDeg() >= -23 && GetAngleViseeDeg() <= 24)
                   spriteBatch.Draw(textures[0,pas], rectangle, Color.White);

                if (GetAngleViseeDeg() >= 24 && GetAngleViseeDeg() <= 68)
                    spriteBatch.Draw(textures[1,pas], rectangle, Color.White);

                if (GetAngleViseeDeg() >= 68 && GetAngleViseeDeg() <= 114)
                    spriteBatch.Draw(textures[2,pas], rectangle, Color.White);

                if (GetAngleViseeDeg() >= 114 && GetAngleViseeDeg() <= 158)
                    spriteBatch.Draw(textures[3,pas], rectangle, Color.White);

                if ((GetAngleViseeDeg() >= 158 && GetAngleViseeDeg() <= 180) || (GetAngleViseeDeg() >= -180 && GetAngleViseeDeg() <= -158))
                    spriteBatch.Draw(textures[4,pas], rectangle, Color.White);

                if (GetAngleViseeDeg() >= -158 && GetAngleViseeDeg() <= -114)
                    spriteBatch.Draw(textures[5,pas], rectangle, Color.White);

                if (GetAngleViseeDeg() >= -114 && GetAngleViseeDeg() <= -68)
                    spriteBatch.Draw(textures[6,pas], rectangle, Color.White);

                if (GetAngleViseeDeg() >= -68 && GetAngleViseeDeg() <= -23)
                    spriteBatch.Draw(textures[7,pas], rectangle, Color.White);
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

            return new Zombie(pop_position, zombiespeed, Game1.textures_zombies, Game1.zombie_mort);

        }



        public void SetMarche()
        {
            if (direction != Vector2.Zero)
            {
                dist_marche += 1;
            }
            if (dist_marche >= 15/speed)
            {
                dist_marche = 0;
                pas += 1;
                pas = pas % 2;
            }
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

        public int GetHealth()
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


        public void SetTarget()
        {
            target = new Rectangle(rectangle.X + 10, rectangle.Y + rectangle.Height - 15, rectangle.Width / 2 + 5, rectangle.Height / 10);
        }

        public Rectangle GetTarget()
        {
            return target;
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
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)(textures[0,0].Width / 2.7), (int)(textures[0,0].Height / 2.7));
        }

        public Vector2 GetRectangleCenter()
        {
            return new Vector2(rectangle.Center.X, rectangle.Center.Y);
        }


        public Texture2D GetTexture()
        {
            return textures[0,0];
        }




    } // End Class
}
