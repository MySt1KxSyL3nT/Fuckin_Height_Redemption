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
    public class GamePadEvent
    {
        public GamePadEvent(PlayerIndex index)
        {
            this.index = index;
        }

        private GamePadState manette;
        private PlayerIndex index;

        public bool Connected()
        {
            return manette.IsConnected;
        }

        public void UpdateGamepad()
        {
            manette = GamePad.GetState(index);
        }

        public Vector2 GetLeftStick()
        {
            return manette.ThumbSticks.Left;
        }

        public Vector2 GetRightStick()
        {
            return manette.ThumbSticks.Right;
        }

        public bool IsPressed(Buttons b)
        {
            return manette.IsButtonDown(b);
        }
    }
}
