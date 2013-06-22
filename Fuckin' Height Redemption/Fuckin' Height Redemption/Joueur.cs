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
    public class Joueur
    {
        public Joueur(string path, Texture2D[,] texture_usp, Texture2D[,] texture_ak47, Texture2D[,] texture_mp5, Texture2D[,] texture_m3, ContentManager Content, int height, int width)
        {
            Load(path, Content);
            this.height = height;
            this.width = width;


            this.texture_usp = texture_usp;
            this.texture_ak47 = texture_ak47;
            this.texture_mp5 = texture_mp5;
            this.texture_m3 = texture_m3;

            this.position = new Vector2(width / 2  - texture_ak47[1,1].Width / 6, height / 2 - texture_ak47[1,1].Height / 6 );
            this.init_position = this.position;

            this.health = 100;

            reloading = false;

            current_weapon = 0;
            dist_marche = 0;
            pas = 0;

            SetSpeed(2);
            SetRectangle();
        }



        /// <summary>
        /// charge la save "path"
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Content"></param>
        public void Load(string path, ContentManager Content)
        {
            string[] data_saved;
            // 0 = name, 1 = argent, 2 = m3 unlocked, 3 = mp5 unlocked, 4 = ak unlocked, 5 = usp level, 6 = mp5 level, 7 = ak level, 8 = m3 level
            if (!File.Exists("solo.save"))
            {
                try
                {
                    StreamWriter file = new StreamWriter(path);
                    file.WriteLine("Joueur");
                    file.WriteLine("0");
                    file.WriteLine("0");
                    file.WriteLine("0");
                    file.WriteLine("0");
                    file.WriteLine("1");
                    file.WriteLine("1");
                    file.WriteLine("1");
                    file.WriteLine("1");
                    file.Close();
                }
                catch
                {
                    Console.WriteLine("Erreur: pas de save creee");
                }
            }
            data_saved = File.ReadAllLines("solo.save");
            this.name = data_saved[0];
            this.money = Int32.Parse(data_saved[1]);
            this.weapons = new Weapon[4];
            weapons[0] = new Weapon("USP", 1, Int32.Parse(data_saved[5]), Content);
            weapons[1] = new Weapon("AK47", Int32.Parse(data_saved[4]), Int32.Parse(data_saved[7]), Content);
            weapons[2] = new Weapon("MP5", Int32.Parse(data_saved[3]), Int32.Parse(data_saved[6]), Content);
            weapons[3] = new Weapon("ShotGun", Int32.Parse(data_saved[2]), Int32.Parse(data_saved[8]), Content);
        }

        public void Save(string path)
        {
            string[] temp = new string[9] { name, Convert.ToString(money), weapons[3].unlocked ? "1" : "0", weapons[2].unlocked ? "1" : "0", weapons[1].unlocked ? "1" : "0", Convert.ToString(weapons[0].GetLevel()), Convert.ToString(weapons[2].GetLevel()), Convert.ToString(weapons[1].GetLevel()), Convert.ToString(weapons[3].GetLevel()) };
            StreamWriter file = new StreamWriter(path);
            foreach (string s in temp)
                file.WriteLine(s);
            file.Close();
        }



        public void Update(int height, int width, GameTime gameTime)
        {
            if (Game1.jeu_manette && Game1.manette.Connected())
            {
                MoveGamePad(Game1.manette, height, width, Game1.zombie);
                if (Game1.manette.GetRightStick() != Vector2.Zero)
                    SetAngleVisee(Game1.manette);

                if (!Game1.manette.IsPressed(Buttons.Start) && Game1.manette_old.IsPressed(Buttons.Start))
                {
                    Game1.status = "Pause";
                    Game1.manette_old = new GamePadEvent(PlayerIndex.One);
                }

                if (!Game1.manette.IsPressed(Buttons.Back) && Game1.manette_old.IsPressed(Buttons.Back))
                {
                    Game1.status = "Magasin";
                    Game1.manette_old = new GamePadEvent(PlayerIndex.One);
                }

                if (Game1.manette.IsPressed(Buttons.RightTrigger))
                    Fire(Game1.zombie, height, width);

                if (Game1.manette.IsPressed(Buttons.X))
                    Reload();

                if (Game1.manette_old.IsPressed(Buttons.Y) && !Game1.manette.IsPressed(Buttons.Y))
                    Game1.joueur.Switch_Weapon(1);

                UpdateShootCooldown(gameTime.ElapsedGameTime.Milliseconds);
                UpdateReloadCooldowm(gameTime.ElapsedGameTime.Milliseconds);

                // update le bool pour le tir semi auto 
                SetLastShoot(Game1.manette.IsPressed(Buttons.RightTrigger));

            }
            else
            {
                MoveKeyboard(Game1.clavier, height, width, Game1.zombie);
                SetAngleVisee(Game1.souris.GetPosition()); // defini l'angle de la visee (vers la souris)

                if (!Game1.clavier.KeyPressed(Keys.Escape) && Game1.clavier_old.KeyPressed(Keys.Escape))
                {
                    Game1.status = "Pause";
                    Game1.souris_old = new MouseEvent();
                    Game1.clavier_old = new KeyboardEvent();
                }


                if (!Game1.clavier.KeyPressed(Keys.X) && Game1.clavier_old.KeyPressed(Keys.X))
                {
                    Game1.status = "Magasin";
                    Game1.souris_old = new MouseEvent();
                    Game1.clavier_old = new KeyboardEvent();
                }


                if (!Game1.clavier.KeyPressed(Keys.M) && Game1.clavier_old.KeyPressed(Keys.M))
                    SetMoney(10000);


                if (Game1.souris.LeftClick())
                    Fire(Game1.zombie, height, width);

                if (Game1.clavier.KeyPressed(Keys.E) && !Game1.joueur.IsReloading())
                    Reload();

                if (Game1.souris.ScrollUp() != Game1.last_molette)
                {
                    Switch_Weapon((Game1.souris.ScrollUp() - Game1.last_molette) / 120);
                    Game1.last_molette = Game1.souris.ScrollUp();
                }

                UpdateShootCooldown(gameTime.ElapsedGameTime.Milliseconds);
                UpdateReloadCooldowm(gameTime.ElapsedGameTime.Milliseconds);

                // update le bool pour le tir semi auto 
                SetLastShoot(Game1.souris.LeftClick());
            }

            SetVisee(); // Creer un vecteur de visee avec l'angle
            SetMarche(); // pour les animations
        }


        public string name;
        private int height, width;

        private int speed;
        private float anglevisee;


        private int health;
        private int money;

        private Vector2 init_position;
        private Vector2 position;
        private Vector2 direction;
        private Vector2 visee;


        private Rectangle rectangle;
        private Rectangle target;// Rectangle plus petit servant de contact aux zombies


        private Texture2D[,] texture_usp;
        private Texture2D[,] texture_ak47;
        private Texture2D[,] texture_mp5;
        private Texture2D[,] texture_m3;



        //armes
        private Weapon[] weapons;
        private int current_weapon;


        private bool last_shoot;
        private int elapsed_time_since_last_shoot; // utiliser pour les tirs auto
        private int elapsed_time_since_reload; // temps de rechargement
        private bool reloading;

        private int dist_marche;// pour l'animation
        private int pas;// pour la texture a afficher



        public void MoveKeyboard(KeyboardEvent clavier, int height, int width, List<Zombie> zombies)
        {
            if (clavier.KeyPressed(Keys.Z))
                direction.Y = -1;
            if (clavier.KeyPressed(Keys.S))
                direction.Y = 1;
            if (clavier.KeyPressed(Keys.Q))
                direction.X = -1;
            if (clavier.KeyPressed(Keys.D))
                direction.X = 1;
            if (clavier.KeyPressed(Keys.S) == clavier.KeyPressed(Keys.Z))
                direction.Y = 0;
            if (clavier.KeyPressed(Keys.Q) == clavier.KeyPressed(Keys.D))
                direction.X = 0;

            // sprint
            if (clavier.KeyPressed(Keys.LeftShift))
                SetSpeed(4);
            else
                SetSpeed(2);


            //colission avec zombies
            foreach (Zombie z in zombies)
            {
                if (z != null && !z.GetDead())
                {
                    if (target.Intersects(z.GetTarget()))
                    {
                        //a gauche
                        if (target.X >= (z.GetTarget().X - target.Width) && target.X <= (z.GetTarget().X - target.Width + 5) && direction.X > 0)
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



            Game1.map.Update(this);
            //SetPosition(position + (direction * speed) + Game1.map.GetDirection());

            /*if (position.Y + rectangle.Height >= height)
                position.Y = height - rectangle.Height;
            else
                if (position.Y <= 0)
                    position.Y = 0;

            if (position.X + rectangle.Width >= width)
                position.X = width - rectangle.Width;
            else
                if (position.X <= 0)
                    position.X = 0;*/


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

            //SetPosition(position + (direction * speed));

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



        public void DrawJoueur(SpriteBatch spriteBatch)
        {
            if (GetAngleViseeDeg() >= -23 && GetAngleViseeDeg() <= 24) // 0
            {
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[0,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[0,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[0,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[0,pas], rectangle, Color.White);
                            break;
                        }
                }
            }

            if (GetAngleViseeDeg() >= 24 && GetAngleViseeDeg() <= 68)// 45
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[1,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[1,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[1,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[1,pas], rectangle, Color.White);
                            break;
                        }
                }

            if (GetAngleViseeDeg() >= 68 && GetAngleViseeDeg() <= 114)// 90
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[2,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[2,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[2,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[2,pas], rectangle, Color.White);
                            break;
                        }
                }

            if (GetAngleViseeDeg() >= 114 && GetAngleViseeDeg() <= 158)// 135
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[3,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[3,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[3,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[3,pas], rectangle, Color.White);
                            break;
                        }
                }

            if ((GetAngleViseeDeg() >= 158 && GetAngleViseeDeg() <= 180) || (GetAngleViseeDeg() >= -180 && GetAngleViseeDeg() <= -158))// 180
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[4,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[4,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[4,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[4,pas], rectangle, Color.White);
                            break;
                        }
                }

            if (GetAngleViseeDeg() >= -158 && GetAngleViseeDeg() <= -114)// 225
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[5,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[5,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[5,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[5,pas], rectangle, Color.White);
                            break;
                        }
                }

            if (GetAngleViseeDeg() >= -114 && GetAngleViseeDeg() <= -68)// 270
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[6,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[6,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[6,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[6,pas], rectangle, Color.White);
                            break;
                        }
                }

            if (GetAngleViseeDeg() >= -68 && GetAngleViseeDeg() <= -23)// 315
                switch (current_weapon)
                {
                    case 0:
                        {
                            spriteBatch.Draw(texture_usp[7,pas], rectangle, Color.White);
                            break;
                        }

                    case 1:
                        {
                            spriteBatch.Draw(texture_ak47[7,pas], rectangle, Color.White);
                            break;
                        }

                    case 2:
                        {
                            spriteBatch.Draw(texture_mp5[7,pas], rectangle, Color.White);
                            break;
                        }

                    case 3:
                        {
                            spriteBatch.Draw(texture_m3[7,pas], rectangle, Color.White);
                            break;
                        }
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
        public void UpdateReloadCooldowm(int elapsed)
        {
            elapsed_time_since_reload += elapsed;
            if (elapsed_time_since_reload >= weapons[current_weapon].reload_time && reloading)
            {
                Console.WriteLine("Reloaded !");
                reloading = false;
            }
        }



        // fire clavier
        public void Fire(List<Zombie> zombies, int height, int width)
        {
            if (weapons[current_weapon].current_clip > 0 && !reloading)
            {
                if (!weapons[current_weapon].autoshoot && !last_shoot && elapsed_time_since_last_shoot > weapons[current_weapon].cooldown)
                {
                    //Console.WriteLine("{0} / {1}", weapons[current_weapon].current_clip, weapons[current_weapon].ammo);
                    FireSemiAuto(zombies, height, width);
                    elapsed_time_since_last_shoot = 0;
                    weapons[current_weapon].tir.Play();
                }
                if (weapons[current_weapon].autoshoot && elapsed_time_since_last_shoot > weapons[current_weapon].cooldown)
                {
                    //Console.WriteLine("{0} / {1}", weapons[current_weapon].current_clip, weapons[current_weapon].ammo);
                    FireAuto(zombies, height, width);
                    elapsed_time_since_last_shoot = 0;
                    weapons[current_weapon].tir.Play();
                }
                
            }
            else
            {
                if (weapons[current_weapon].current_clip <= 0 && weapons[current_weapon].ammo > 0)
                {
                    Reload();
                    Console.WriteLine("reload");
                }
                else
                    Console.WriteLine("Reloading !");
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
                        if (z.GetHealth() <= 0)
                        {
                            money += Game1.difficulté.GetMoneyEarned();
                        }
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
            float x = rectangle.Center.X;
            float y = rectangle.Center.Y;
            bool touched = false;
            while (!touched && x > 0 && x < width && y > 0 && y < height)
            {
                x += 5 * visee.X;
                y += 5 * visee.Y;
                foreach (Zombie z in zombies)
                {
                    if (!z.GetDead() && z.GetRectangle().Contains((int)x, (int)y) && !touched)
                    {
                        touched = true;
                        z.Hurt(weapons[current_weapon].dmg);
                        if (z.GetHealth() <= 0)
                        {
                            money += Game1.difficulté.GetMoneyEarned();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// recharge l'arme en cours
        /// </summary>
        public void Reload()
        {
            if (weapons[current_weapon].current_clip < weapons[current_weapon].clip_max && weapons[current_weapon].ammo > 0)
            {
                if (weapons[current_weapon].name == "ShotGun")
                {
                    switch (weapons[current_weapon].current_clip)
                    {
                        case 0:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement8.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement8;
                                break;
                            }
                        case 1:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement7.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement7;
                                break;
                            }
                        case 2:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement6.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement6;
                                break;
                            }
                        case 3:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement5.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement5;
                                break;
                            }
                        case 4:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement4.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement4;
                                break;
                            }
                        case 5:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement3.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement3;
                                break;
                            }
                        case 6:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement2.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement2;
                                break;
                            }
                        default:
                            {
                                weapons[current_weapon].reload_time = (int)weapons[current_weapon].rechargement1.Duration.TotalMilliseconds;
                                weapons[current_weapon].rechargement = weapons[current_weapon].rechargement1;
                                break;
                            }
                    }
                }

                if (weapons[current_weapon].ammo <= weapons[current_weapon].clip_max - weapons[current_weapon].current_clip)
                {
                    weapons[current_weapon].current_clip += weapons[current_weapon].ammo;
                    weapons[current_weapon].ammo = 0;
                    elapsed_time_since_reload = 0;
                    reloading = true;
                }
                else
                {
                    weapons[current_weapon].ammo -= weapons[current_weapon].clip_max - weapons[current_weapon].current_clip;
                    weapons[current_weapon].current_clip = weapons[current_weapon].clip_max;
                    elapsed_time_since_reload = 0;
                    reloading = true;
                }
                weapons[current_weapon].rechargement.Play();
            }
        }

        public void Switch_Weapon(int n)
        {
            if (!reloading)
            {
                current_weapon -= n;
                if (current_weapon >= 4)
                    current_weapon = 0;
                if (current_weapon <= -1)
                    current_weapon = 3;
                if (!weapons[current_weapon].unlocked)
                    Switch_Weapon(n);
                Console.WriteLine(weapons[current_weapon].name);
            }
        }









        //////////// POUR MAGASIN ////////////

        public void Debloque_Weapon(Weapon arme)
        {
            if (arme == weapons[3])//m3
                this.money -= 5000;
            if (arme == weapons[2])//mp5
                this.money -= 10000;
            if (arme == weapons[1])//ak47
                this.money -= 50000;
        }

        public void ChangeHealth(string drogue)
        {
            if (drogue == "shit")
            {
                this.health += 10;
                this.money -= 200;
            }
            if (drogue == "coke")
            {
                if (this.health >= 50)
                    this.health = 100;
                else
                    this.health += 50;
                this.money -= 500;
            }
            if (drogue == "seringue")
            {
                this.health = 100;
                this.money -= 1000;
            }
        }



        public Weapon GetWeapons(string arme)
        {
            if (arme == "m3")
                return weapons[3];
            if (arme == "usp")
                return weapons[0];
            if (arme == "ak47")
                return weapons[1];
            if (arme == "mp5")
                return weapons[2];
            else
                return weapons[0];
        }

        public Weapon[] GetWeapons()
        {
            return weapons;
        }







        public bool IsReloading()
        {
            return reloading;
        }

        public void SetMarche()
        {
            if (direction != Vector2.Zero)
            {
               dist_marche += 1;
            }
            if (dist_marche >= 10)
            {
                dist_marche = 0;
                pas += 1;
                pas = pas % 4;
            }
        }

        public int GetMoney()
        {
            return money;
        }

        public void SetMoney(int n)
        {
            money += n;
        }


        public int GetCurrentWeapon()
        {
            return current_weapon;
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

        public void SetAngleVisee(GamePadEvent manette)
        {
            double rad = Math.Atan2(-manette.GetRightStick().Y, manette.GetRightStick().X);
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

        public Vector2 GetInitPosition()
        {
            return init_position;
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
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)(texture_usp[0, 0].Width / 3), (int)(texture_usp[0, 0].Height / 3));
        }

        public Vector2 GetRectangleCenter()
        {
            return new Vector2(rectangle.X + rectangle.Width/2 + 20, rectangle.Y + rectangle.Height/2);
        }


        public void SetTarget()
        {
            target = new Rectangle(rectangle.X + 37, rectangle.Y + rectangle.Height - 30, rectangle.Width / 3, rectangle.Height / 10);
        }
        public Rectangle GetTarget()
        {
            return target;
        }


        public Texture2D GetTexture()
        {
            return texture_usp[0, 0];
        }


        public void SetName(string s)
        {
            name = s;
        }


    } // End Class
}
