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
        public Joueur(Vector2 position, Texture2D texture0, Texture2D texture45, Texture2D texture90, Texture2D texture135, Texture2D texture180, Texture2D texture225, Texture2D texture270, Texture2D texture315)
        {
            this.texture0 = texture0;
            this.texture45 = texture45;
            this.texture90 = texture90;
            this.texture135 = texture135;
            this.texture180 = texture180;
            this.texture225 = texture225;
            this.texture270 = texture270;
            this.texture315 = texture315;
            this.position = position;
            SetSpeed(2);
            SetRectangle();
        }

        private int speed;
        private Vector2 position;
        private Vector2 direction;
        private Rectangle rectangle;
        private Rectangle target; // Rectangle plus petit servant de contact aux zombies

        private Texture2D texture0;
        private Texture2D texture45;
        private Texture2D texture90;
        private Texture2D texture135;
        private Texture2D texture180;
        private Texture2D texture225;
        private Texture2D texture270;
        private Texture2D texture315;



        public void MoveKeyboard(KeyboardEvent clavier, int height, int width)
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

            SetPosition(position + (direction * speed));

            if (position.Y + texture0.Height >= height)
                position.Y = height - texture0.Height;
            else
                if (position.Y <= 0)
                    position.Y = 0;

            if (position.X + texture0.Width >= width)
                position.X = width - texture0.Width;
            else
                if (position.X <= 0)
                    position.X = 0;

            SetRectangle();
            SetTartget();
        }

        public void MoveGamePad(GamePadEvent manette, int height, int width)
        {
            direction.X = manette.GetLeftStick().X;
            direction.Y = -manette.GetLeftStick().Y;

            // sprint
            if (manette.IsPressed(Buttons.A))
                SetSpeed(4);
            else
                SetSpeed(2);

            SetPosition(position + (direction * speed));

            if (position.Y + texture0.Height >= height)
                position.Y = height - texture0.Height;
            else
                if (position.Y <= 0)
                    position.Y = 0;

            if (position.X + texture0.Width >= width)
                position.X = width - texture0.Width;
            else
                if (position.X <= 0)
                    position.X = 0;
            SetRectangle();
            SetTartget();
        }


        public void DrawJoueur(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture0, position, Color.White); 
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
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture0.Width, texture0.Height);
        }

        public void SetTartget()
        {
            target = new Rectangle(rectangle.X + texture0.Width / 3, rectangle.Y + texture0.Height / 3, texture0.Width / 2, texture0.Height / 2);
        }

        public Rectangle GetTarget()
        {
            return target;
        }

        public Texture2D GetTexture()
        {
            return texture0;
        }


    } // End Class
}
