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
        public Weapon(string name, ContentManager Content)
        {
            this.name = name;
            if (name == "USP")
            {
                clip_max = 8;
                current_clip = 8;
                ammo = 10000;
                ammo_max = 100000;
                dmg = 20;
                unlocked = true;
                autoshoot = false;
                cooldown = 150;
                tir = Content.Load<SoundEffect>("tir_usp");
                rechargement = Content.Load<SoundEffect>("recharge_usp");
                reload_time = (int)rechargement.Duration.TotalMilliseconds;
            }
            if (name == "ShotGun")
            {
                clip_max = 8;
                current_clip = 8;
                ammo = 16;
                ammo_max = 40;
                dmg = 100;
                unlocked = true;
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
                clip_max = 20;
                current_clip = 20;
                ammo = 60;
                ammo_max = 100;
                dmg = 10;
                unlocked = true;
                autoshoot = true;
                cooldown = 80;
                tir = Content.Load<SoundEffect>("tir_mp5");
                rechargement = Content.Load<SoundEffect>("recharge_mp5");
                reload_time = (int)rechargement.Duration.TotalMilliseconds;
            }
            if (name == "AK47")
            {
                clip_max = 30;
                current_clip = 30;
                ammo = 120;
                ammo_max = 240;
                dmg = 30;
                unlocked = true;
                autoshoot = true;
                cooldown = 115;
                tir = Content.Load<SoundEffect>("tir_ak47");
                rechargement = Content.Load<SoundEffect>("recharge_ak47");
                reload_time = (int)rechargement.Duration.TotalMilliseconds;
            }
        }

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
    }
}
