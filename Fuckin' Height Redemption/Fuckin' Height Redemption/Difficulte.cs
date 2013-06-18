using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fuckin__Height_Redemption
{
    public class Difficulté
    {
        public Difficulté(int lv)
        {
            if (lv == 1)
            {
                maxZombies = 1;
                maxSpeed = 3;
                millisecondToPop = 6000;
                moneyEarned = 50;
            }
            if (lv == 2)
            {
                maxZombies = 50;
                maxSpeed = 5;
                millisecondToPop = 3000;
                moneyEarned = 100;
            }
            if (lv == 3)
            {
                maxZombies = 200;
                maxSpeed = 7;
                millisecondToPop = 1200;
                moneyEarned = 150;
            }
            if (lv == 4)
            {
                maxZombies = 1000;
                maxSpeed = 10;
                millisecondToPop = 100;
                moneyEarned = 300;
            }
        }

        private int maxZombies;
        private int maxSpeed;
        private int millisecondToPop;
        private int maxHealth;
        private int moneyEarned;


        public int GetMaxZombies()
        {
            return maxZombies;
        }

        public int GetMaxSpeed()
        {
            return maxSpeed;
        }

        public int GetMilliseconds()
        {
            return millisecondToPop;
        }

        public int GetMoneyEarned()
        {
            return moneyEarned;
        }

    }
}
