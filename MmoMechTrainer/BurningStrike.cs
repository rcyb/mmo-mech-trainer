using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MmoMechTrainer
{
    class BurningStrike
    {
        protected Texture2D _texture;
        public Vector2 Position;
        public Color Colour;
        //public Input Input;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public BurningStrike(Texture2D texture)
        {
            _texture = texture;
        }

        //public virtual void Update(GameTime gameTime, List<BurningStrike>)
        //{

        //}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(0, 0, 250, 2000), Colour);
        }
    }
}
