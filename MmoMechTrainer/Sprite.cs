using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MmoMechTrainer
{
    class Sprite
    {
        private Texture2D _texture;
        

        public Vector2 Position;
        public Vector2 Origin;

        public float rotationVelocity = 3f;
        public float Linearvelocity = 4f;

        public Color Color;
        public Vector2 Size;
        public Rectangle DestinationRectangle;
        public float Rotation;



        public float Speed = 2f;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, DestinationRectangle, null, Color.White, Rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1.0F);
            //spriteBatch.Draw(_texture, Position, SourceRectangle, Color, _rotation, Origin, Scale, SpriteEffects.None, 0f );
        }
    }
}
