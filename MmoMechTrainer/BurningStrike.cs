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
        private float burntStrikeOpacity;
        public float burntStrikeRotation;
        public Color Colour;
        public Boolean fireBurningStrike;
        private int firstPhaseCounter = 200;
        bool isFired = false;



        public BurningStrike(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (fireBurningStrike)
            {
                if (firstPhaseCounter > 50)
                {
                    _texture.SetData(new[] { new Color(0, 0, 0, 0) });
                }
                if (firstPhaseCounter < 50 && !isFired)
                {
                    // Debug.WriteLine(bigDaddyPosition);
                    _texture.SetData(new[] { new Color(255, 0, 0, 1.0F) });
                    burntStrikeOpacity = 1.0F;
                    isFired = true;
                }
                burntStrikeOpacity = burntStrikeOpacity - 0.01F;
                if (firstPhaseCounter == 0)
                {
                    _texture.SetData(new[] { new Color(0, 0, 0,0) });
                    fireBurningStrike = false;
                }
                firstPhaseCounter -= 1;
            }

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, destinationRectangle: new Rectangle((int)BossPosition.X - 250 / 2, (int)BossPosition.Y - 2000 / 2, 250, 2000), null, new Color(255, 0, 0, burntStrikeOpacity), burntStrikeRotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 0.5F);
        }
    }
}
