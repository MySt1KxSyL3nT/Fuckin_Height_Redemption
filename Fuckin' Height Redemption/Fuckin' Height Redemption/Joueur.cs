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
    class Joueur
    {
        public Joueur(Vector2 position, Texture2D texture2d, Texture2D texture0, Texture2D texture45, Texture2D texture90, Texture2D texture135, Texture2D texture180, Texture2D texture225, Texture2D texture270, Texture2D texture315)
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

            this.health = 100;

            this.weapons = new Weapon[4];
            weapons[0] = new Weapon("USP");
            weapons[1] = new Weapon("ShotGun");
            weapons[2] = new Weapon("Uzi");
            weapons[3] = new Weapon("AK47");

            current_weapon = 0;

            SetSpeed(2);
            SetRectangle();
        }

        private int speed;
        private float anglevisee;


        private int health;


        private Vector2 position;
        private Vector2 direction;
        private Vector2 visee;


        private Rectangle rectangle;
        private Rectangle target;// Rectangle plus petit servant de contact aux zombies


        private Texture2D texture2d;
        private Texture2D texture0;
        private Texture2D texture45;
        private Texture2D texture90;
        private Texture2D texture135;
        private Texture2D texture180;
        private Texture2D texture225;
        private Texture2D texture270;
        private Texture2D texture315;

        //armes
        private Weapon[] weapons;
        private int current_weapon;


        private bool last_shoot;
        private int elapsed_time_since_last_shoot; // utiliser pour les tirs auto



        public void MoveKeyboard(KeyboardEvent clavier, int height, int width, List<Zombie> zombies)
        {
            if (clavier.KeyPressed(Keys.Up))
                direction.Y = -1;
            if (clavier.KeyPressed(Keys.Down))
                direction.Y = 1;
            if (clavier.KeyPressed(Keys.Left))
                direction.X = -1;
            if (clavier.KeyPressed(Keys.Right))
                direction.X = 1;
            if (clavier.KeyPressed(Keys.Down) == clavier.KeyPressed(Keys.Up))
                direction.Y = 0;
            if (clavier.KeyPressed(Keys.Left) == clavier.KeyPressed(Keys.Right))
                direction.X = 0;

            // sprint
            if (clavier.KeyPressed(Keys.RightShift))
                SetSpeed(4);
            else
                SetSpeed(2);


            //colission avec zombies
            foreach (Zombie z in zombies)
            {
                if (z != null && !z.GetDead())
                {
                    if (target.Intersects(z.GetRectangle()))
                    {
                        //a gauche
                        if (target.X >= (z.GetRectangle().X - target.Width) && target.X <= (z.GetRectangle().X - target.Width + 5) && direction.X > 0)
                        {
                            direction.X = 0;
                        }
                        //a droite
                        if (target.X <= z.GetRectangle().X + z.GetRectangle().Width && target.X >= z.GetRectangle().X + z.GetRectangle().Width - 5 && direction.X < 0)
                        {
                            direction.X = 0;
                        }
                        //en haut
                        if (target.Y >= (z.GetRectangle().Y - target.Height) && target.Y <= (z.GetRectangle().Y - target.Height + 5) && direction.Y > 0)
                        {
                            direction.Y = 0;
                        }
                        //en bas
                        if (target.Y <= z.GetRectangle().Y + z.GetRectangle().Height && target.Y >= z.GetRectangle().Y + z.GetRectangle().Height - 5 && direction.Y < 0)
                        {
                            direction.Y = 0;
                        }
                    }
                }
            }




            SetPosition(position + (direction * speed));

            if (position.Y + rectangle.Height >= height)
                position.Y = height - rectangle.Height;
            else
                if (position.Y <= 0)
                    position.Y = 0;

            if (position.X + rectangle.Width >= width)
                position.X = width - rectangle.Width;
            else
                if (position.X <= 0)
                    position.X = 0;


            SetRectangle();
            SetTarget();
        }



        public void MoveGamePad(GamePadEvent manette, int height, int width, List<Zombie> zombies)
        {
            direction.X = manette.GetLeftStick().X;
            direction.Y = -manette.GetLeftStick().Y;

            // sprint
            if (manette.IsPressed(Buttons.A))
                SetSpeed(4);
            else
                SetSpeed(2);

            //colission avec zombies
            foreach (Zombie z in zombies)
            {
                if (!z.GetDead())
                {
                    if (target.Intersects(z.GetRectangle()))
                    {
                        //a gauche
                        if (target.X >= (z.GetRectangle().X - target.Width) && target.X <= (z.GetRectangle().X - target.Width + 5) && direction.X > 0)
                        {
                            direction.X = 0;
                        }
                        //a droite
                        if (target.X <= z.GetRectangle().X + z.GetRectangle().Width && target.X >= z.GetRectangle().X + z.GetRectangle().Width - 5 && direction.X < 0)
                        {
                            direction.X = 0;
                        }
                        //en haut
                        if (target.Y >= (z.GetRectangle().Y - target.Height) && target.Y <= (z.GetRectangle().Y - target.Height + 5) && direction.Y > 0)
                        {
                            direction.Y = 0;
                        }
                        //en bas
                        if (target.Y <= z.GetRectangle().Y + z.GetRectangle().Height && target.Y >= z.GetRectangle().Y + z.GetRectangle().Height - 5 && direction.Y < 0)
                        {
                            direction.Y = 0;
                        }
                    }
                }
            }

            SetPosition(position + (direction * speed));

            if (position.Y + rectangle.Height >= height)
                position.Y = height - rectangle.Height;
            else
                if (position.Y <= 0)
                    position.Y = 0;

            if (position.X + rectangle.Width >= width)
                position.X = width - rectangle.Width;
            else
                if (position.X <= 0)
                    position.X = 0;
            SetRectangle();
            SetTarget();
        }



        public void DrawJoueur(SpriteBatch spriteBatch, bool iso2D)
        {
            if (iso2D)
            {
                spriteBatch.Draw(GetTexture2d(), new Rectangle(GetRectangle().X + GetRectangle().Width / 2, GetRectangle().Y + GetRectangle().Height / 2, GetRectangle().Width, GetRectangle().Height), null, Color.White, GetAngleVisee(), new Vector2(GetTexture().Width / 2, GetTexture().Height / 2), SpriteEffects.None, 0f);
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



        public void Hurt(int dmg)
        {
            this.health -= dmg;
        }
        public void Heal(int hp)
        {
            this.health += hp;
            if (health > 100)
                health = 100;
        }
        public int GetHealth()
        {
            return health;
        }


        public void SetLastShoot(bool last)
        {
            last_shoot = last;
        }
        public void UpdateShootCooldown(int elapsed)
        {
            elapsed_time_since_last_shoot += elapsed;
        }

        // fire clavier
        public void Fire(List<Zombie> zombies, int height, int width)
        {
            if (weapons[current_weapon].current_clip >= 0)
            {
                if (!weapons[current_weapon].autoshoot && !last_shoot)
                {
                    Console.WriteLine("{0} / {1}", weapons[current_weapon].current_clip, weapons[current_weapon].clip_max);
                    FireSemiAuto(zombies, height, width);
                    elapsed_time_since_last_shoot = 0;
                    
                }
                if(weapons[current_weapon].autoshoot && elapsed_time_since_last_shoot > weapons[current_weapon].cooldown)
                {
                    Console.WriteLine("{0} / {1}", weapons[current_weapon].current_clip, weapons[current_weapon].clip_max);
                    FireAuto(zombies, height, width);
                    elapsed_time_since_last_shoot = 0;
                }
            }
            else
            {
                Reload();
                Console.WriteLine("reload");
            }
        }

        /// <summary>
        /// tir semi automatique
        /// </summary>
        /// <param name="zombies"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void FireSemiAuto(List<Zombie> zombies, int height, int width)
        {
            weapons[current_weapon].current_clip -= 1;
            float x = rectangle.Center.X;
            float y = rectangle.Center.Y;
            bool touched = false;
            while (!touched && x > 0 && x < width && y > 0 && y < height)
            {
                x += 5 * visee.X;
                y += 5 * visee.Y;
                foreach (Zombie z in zombies)
                {
                    if (!z.GetDead() && z.GetRectangle().Contains((int)x, (int)y))
                    {
                        touched = true;
                        z.Hurt(weapons[current_weapon].dmg);
                    }
                }
            }

        }

        /// <summary>
        /// tir auto
        /// </summary>
        /// <param name="zombies"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        public void FireAuto(List<Zombie> zombies, int height, int width)
        {
            weapons[current_weapon].current_clip -= 1;
        }

        /// <summary>
        /// recharge l'arme en cours
        /// </summary>
        public void Reload()
        {
            if (weapons[current_weapon].ammo <= weapons[current_weapon].clip_max - weapons[current_weapon].current_clip)
            {
                weapons[current_weapon].current_clip += weapons[current_weapon].ammo;
                weapons[current_weapon].ammo = 0;
            }
            else
            {
                weapons[current_weapon].ammo -= weapons[current_weapon].clip_max - weapons[current_weapon].current_clip;
                weapons[current_weapon].current_clip = weapons[current_weapon].clip_max;
            }
        }




        public void SetVisee()
        {
            visee = new Vector2((float)Math.Cos(anglevisee), (float)Math.Sin(anglevisee));
        }

        public Vector2 GetVisee()
        {
            return visee;
        }


        public void SetAngleVisee(Vector2 souris_position)
        {
            Vector2 angle;
            angle.X = souris_position.X - rectangle.Center.X;
            angle.Y = souris_position.Y - rectangle.Center.Y;

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


        public int GetSpeed()
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


        public void SetTarget()
        {
            target = new Rectangle(rectangle.X + rectangle.Width / 3 + 10, rectangle.Y + rectangle.Height / 3 + 10, rectangle.Width / 8, rectangle.Height / 8);
        }

        public Rectangle GetTarget()
        {
            return target;
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
