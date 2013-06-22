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
    public class Weapon
    {
        public Weapon(string name, int unlock, int lvl, ContentManager Content)
        {
            this.Content = Content;
            this.name = name;
            if (unlock == 1)
                unlocked = true;
            else
                unlocked = false;

            if (name == "USP")
            {
                level = 1;
                clip_max = 8;
                current_clip = 8;
                ammo = 10000;
                ammo_max = 100000;
                dmg = 20;
                autoshoot = false;
                cooldown = 150;
                tir = Content.Load<SoundEffect>("tir_usp");
                rechargement = Content.Load<SoundEffect>("recharge_usp");
                reload_time = (int)rechargement.Duration.TotalMilliseconds;
            }
            if (name == "ShotGun")
            {
                level = 1;
                clip_max = 8;
                current_clip = 8;
                ammo = 16;
                ammo_max = 40;
                dmg = 100;
                autoshoot = false;
                tir = Content.Load<SoundEffect>("tir_m3");
                rechargement1 = Content.Load<SoundEffect>("recharge_m3_1");
                rechargement2 = Content.Load<SoundEffect>("recharge_m3_2");
                rechargement3 = Content.Load<SoundEffect>("recharge_m3_3");
                rechargement4 = Content.Load<SoundEffect>("recharge_m3_4");
                rechargement5 = Content.Load<SoundEffect>("recharge_m3_5");
                rechargement6 = Content.Load<SoundEffect>("recharge_m3_6");
                rechargement7 = Content.Load<SoundEffect>("recharge_m3_7");
                rechargement8 = Content.Load<SoundEffect>("recharge_m3_8");
                reload_time = (int)rechargement1.Duration.TotalMilliseconds;
                cooldown = (int)tir.Duration.TotalMilliseconds - 300; // - 300 car son 0.3 sec trop long
            }
            if (name == "MP5")
            {
                level = 1;
                clip_max = 20;
                current_clip = 20;
                ammo = 60;
                ammo_max = 100;
                dmg = 10;
                autoshoot = true;
                cooldown = 80;
                tir = Content.Load<SoundEffect>("tir_mp5");
                rechargement = Content.Load<SoundEffect>("recharge_mp5");
                reload_time = (int)rechargement.Duration.TotalMilliseconds;
            }
            if (name == "AK47")
            {
                level = 1;
                clip_max = 30;
                current_clip = 30;
                ammo = 120;
                ammo_max = 240;
                dmg = 30;
                autoshoot = true;
                cooldown = 115;
                tir = Content.Load<SoundEffect>("tir_ak47");
                rechargement = Content.Load<SoundEffect>("recharge_ak47");
                reload_time = (int)rechargement.Duration.TotalMilliseconds;
            }

            while (level < lvl)
            {
                AddLevel();
            }
        }

        private ContentManager Content;
        public string name; //nom
        public int clip_max; // munition max chargeur
        public int current_clip; // munition en cours
        public int ammo; // munitions de recharge
        public int ammo_max; // munitions max de recharge
        public int dmg; // dmg

        public SoundEffect tir;
        public SoundEffect rechargement;
        public SoundEffect rechargement1;
        public SoundEffect rechargement2;
        public SoundEffect rechargement3;
        public SoundEffect rechargement4;
        public SoundEffect rechargement5;
        public SoundEffect rechargement6;
        public SoundEffect rechargement7;
        public SoundEffect rechargement8;

        public bool unlocked; // debloque
        public bool autoshoot; // tir auto
        public int cooldown; // temps entre deux tir pour les auto (millisec)
        public int reload_time; // temps de rechargement (millisec)
        private int level; // ammos/clip/tir/recharge/dmg

        public int GetLevel()
        {
            return level;
        }

        public void AddLevel()
        {
            this.level++;

            if (level == 2) // ammo
            {
                switch (name)
                {
                    case "USP":
                        clip_max = 12;
                        break;
                    case "ShotGun":
                        ammo_max = 60;
                        ammo = ammo_max;
                        break;
                    case "MP5":
                        ammo_max = 160;
                        ammo = ammo_max;
                        break;
                    case "AK47":
                        ammo_max = 300;
                        ammo = ammo_max;
                        break;
                }
            }

            if (level == 3) // clip
            {
                switch (name)
                {
                    case "USP":
                        clip_max = 15;
                        break;
                    case "ShotGun":
                        ammo_max = 80;
                        ammo = ammo_max;
                        break;
                    case "MP5":
                        clip_max = 30;
                        break;
                    case "AK47":
                        clip_max = 45;
                        break;
                }
            }

            if (level == 4) //tir
            {
                switch (name)
                {
                    case "USP":
                        cooldown = 110;
                        break;
                    case "ShotGun":
                        tir = Content.Load<SoundEffect>("tir_m3_2");
                        cooldown = (int)tir.Duration.TotalMilliseconds - 400; // - 300 car son 0.3 sec trop long
                        break;
                    case "MP5":
                        cooldown = 60;
                        break;
                    case "AK47":
                        cooldown = 90;
                        break;
                }
            }

            if (level == 5) //recharge
            {
                switch (name)
                {
                    case "USP":
                        rechargement = Content.Load<SoundEffect>("recharge_usp_2");
                        reload_time = (int)rechargement.Duration.TotalMilliseconds;
                        break;
                    case "ShotGun":
                        rechargement1 = Content.Load<SoundEffect>("recharge_m3_1_2");
                        rechargement2 = Content.Load<SoundEffect>("recharge_m3_2_2");
                        rechargement3 = Content.Load<SoundEffect>("recharge_m3_3_2");
                        rechargement4 = Content.Load<SoundEffect>("recharge_m3_4_2");
                        rechargement5 = Content.Load<SoundEffect>("recharge_m3_5_2");
                        rechargement6 = Content.Load<SoundEffect>("recharge_m3_6_2");
                        rechargement7 = Content.Load<SoundEffect>("recharge_m3_7_2");
                        rechargement8 = Content.Load<SoundEffect>("recharge_m3_8_2");
                        break;
                    case "MP5":
                        rechargement = Content.Load<SoundEffect>("recharge_mp5_2");
                        reload_time = (int)rechargement.Duration.TotalMilliseconds;
                        break;
                    case "AK47":
                        rechargement = Content.Load<SoundEffect>("recharge_ak47_2");
                        reload_time = (int)rechargement.Duration.TotalMilliseconds;
                        break;
                }
            }

            if (level == 6) //dmg
            {
                switch (name)
                {
                    case "USP":
                        dmg = 35;
                        break;
                    case "ShotGun":
                        dmg = 150;
                        break;
                    case "MP5":
                        dmg = 25;
                        break;
                    case "AK47":
                        dmg = 50;
                        break;
                }
            }
        }
    }
}
