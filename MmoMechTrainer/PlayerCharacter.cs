using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MmoMechTrainer
{
    class PlayerCharacter
    {
        private Texture2D _texture;
        public Vector2 Position;
        public Vector2 Size;
        public float WindowWidth;
        public float WindowHeight;

        public float Speed = 2f;

        public PlayerCharacter(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position.X -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position.X += Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                Position.Y -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                Position.Y += Speed;
            }

            if (Position.X > WindowWidth)
                Position.X = 0;
            if (Position.X < 0)
                Position = new Vector2(WindowWidth / 2F, WindowHeight / 4F);
            if (Position.Y > WindowHeight)
                Position.Y = 0;
            if (Position.Y < 0)
                Position = new Vector2(WindowWidth / 2F, WindowHeight / 4F);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle: new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), null, Color.White, 0.0F, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 0.5F);
        }
    }
}

