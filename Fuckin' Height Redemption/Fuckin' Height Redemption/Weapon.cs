using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuckin__Height_Redemption
{
    class Weapon
    {
        public Weapon(string name)
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
                playing = true;
                autoshoot = false;
                cooldown = 0;
                reload_time = 750;
            }
            if (name == "ShotGun")
            {
                clip_max = 8;
                current_clip = 8;
                ammo = 16;
                ammo_max = 40;
                dmg = 100;
                unlocked = true;
                playing = false;
                autoshoot = false;
                cooldown = 0;
                reload_time = 500;
            }
            if (name == "Uzi")
            {
                clip_max = 20;
                current_clip = 20;
                ammo = 60;
                ammo_max = 100;
                dmg = 10;
                unlocked = true;
                playing = false;
                autoshoot = true;
                cooldown = 80;
                reload_time = 1500;
            }
            if (name == "AK47")
            {
                clip_max = 30;
                current_clip = 30;
                ammo = 120;
                ammo_max = 240;
                dmg = 10;
                unlocked = true;
                playing = false;
                autoshoot = true;
                cooldown = 115;
                reload_time = 2000;
            }
        }

        public string name; //nom
        public int clip_max; // munition max chargeur
        public int current_clip; // munition en cours
        public int ammo; // munitions de recharge
        public int ammo_max; // munitions max de recharge
        public int dmg; // dmg

        public bool unlocked; // debloque
        public bool playing; // en cours d'utilisation
        public bool autoshoot; // tir auto
        public int cooldown; // temps entre deux tir pour les auto (millisec)
        public int reload_time; // temps de rechargement (millisec)
    }
}
