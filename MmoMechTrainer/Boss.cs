using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MmoMechTrainer
{
    class Boss
    {
        private Texture2D _texture;       
        private Vector2 Size;

        public Vector2 Position;
        public float Rotation;
        public float Speed = 2f;

        public Boss(Texture2D texture)
        {
            _texture = texture;
            Size = new Vector2(150, 150);
            Rotation = 0.0F;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture, 
                destinationRectangle: new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y), 
                null, 
                Color.White, 
                Rotation, 
                new Vector2(_texture.Width / 2, _texture.Height / 2), 
                SpriteEffects.None, 
                1.0F
            );
        }
    }
}
