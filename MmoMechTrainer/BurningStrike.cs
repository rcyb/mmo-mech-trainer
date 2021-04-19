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
        public Vector2 BossPosition;
        public float burntStrikeOpacity;
        public float burntStrikeRotation;
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
            spriteBatch.Draw(_texture, destinationRectangle: new Rectangle((int)BossPosition.X - 250 / 2, (int)BossPosition.Y - 2000 / 2, 250, 2000), null, new Color(255, 0, 0, burntStrikeOpacity), burntStrikeRotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 0.5F);
            //spriteBatch.Draw(_texture, new Rectangle(400, 400, 250, 2000), Colour);
        }
    }
}
