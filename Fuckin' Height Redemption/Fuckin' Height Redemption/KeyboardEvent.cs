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
    class KeyboardEvent
    {
        public KeyboardEvent()
        {

        }

        private KeyboardState clavier;

        /// <summary>
        /// update le clavier
        /// </summary>
        public void UpdateKeyboard()
        {
            clavier = Keyboard.GetState();
        }

        /// <summary>
        /// renvoie si la touche est pressée
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool KeyPressed(Keys key)
        {
            return clavier.IsKeyDown(key);
        }
        
    }
}
