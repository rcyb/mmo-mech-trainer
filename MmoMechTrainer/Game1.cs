using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MmoMechTrainer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;

        private PlayerCharacter pc;
        private BurningStrikeFire burningStrikeFire;
        private BurningStrikeLightning burningStrikeLightning;
        private BurningStrikeLight burningStrikeLight;
        private Boss bigDaddy;


        Texture2D map;
        private const int WindowWidth = 800;
        private const int WindowHeight = 800;
        private int fightDuration = 6000;




        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.IsFixedTimeStep = true;
            _graphics.SynchronizeWithVerticalRetrace = true;

        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = WindowWidth;
            _graphics.PreferredBackBufferHeight = WindowHeight;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = this.Content.Load<Texture2D>("Images/Maps/map");

            var characterIcon = Content.Load<Texture2D>("Images/Classes/sch");
            pc = new PlayerCharacter(characterIcon)
            {
                Speed = 2,
                Position = new Vector2(WindowWidth / 2F, WindowHeight / 4F),
                Size = new Vector2(50, 50),
                WindowHeight = WindowHeight,
                WindowWidth = WindowWidth
            };

            var bigDaddyTexture = this.Content.Load<Texture2D>("Images/Enemies/FFXIV_Fatebreaker_render");
            bigDaddy = new Boss(bigDaddyTexture)
            {
                Position = new Vector2(WindowWidth / 2F + new System.Random().Next(-150, 150), WindowHeight / 2F + new System.Random().Next(-150, 150)),
                Rotation = 0.0F
            };

            var burningStrikeFireTexture = new Texture2D(GraphicsDevice, 1, 1);
            burningStrikeFire = new BurningStrikeFire(burningStrikeFireTexture)
            {
                BossPosition = bigDaddy.Position,
                burntStrikeRotation = 0.0F,
                playerPosition = pc.Position
            };
            var burningStrikeLightningTexture = new Texture2D(GraphicsDevice, 1, 1);
            burningStrikeLightning = new BurningStrikeLightning(burningStrikeLightningTexture)
            {
                BossPosition = bigDaddy.Position,
                burntStrikeRotation = 0.0F
            };
            var burningStrikeLightTexture = new Texture2D(GraphicsDevice, 1, 1);
            burningStrikeLight = new BurningStrikeLight(burningStrikeLightTexture)
            {
                BossPosition = bigDaddy.Position,
                burntStrikeRotation = 0.0F
            };


        }

        protected override void Update(GameTime gameTime)
        {
            
            if(fightDuration > 0)
            {
                if(fightDuration < 5850)
                {
                    burningStrikeFire.fireBurningStrikeFire = true;
                    pc.Position = burningStrikeFire.playerPosition;
                }
                if (fightDuration < 5700)
                {
                    burningStrikeLightning.fireBurningStrikeLightning = true;
                }
                var burntStrikePosition = new Vector2(WindowWidth / 2F, WindowHeight / 2F);
                Vector2 diff = burntStrikePosition - bigDaddy.Position;
                if (bigDaddy.Position.X != 400 && bigDaddy.Position.Y != 400)
                {

                    bigDaddy.Position.X += diff.X / (System.Math.Abs(diff.X) < 1 ? 1 : 10);
                    bigDaddy.Position.Y += diff.Y / (System.Math.Abs(diff.Y) < 1 ? 1 : 10);
                }

                fightDuration -= 1;
                bigDaddy.Update();
                burningStrikeFire.Update();
                burningStrikeLightning.Update();
                burningStrikeLight.Update();
                pc.Update();

                base.Update(gameTime);
            }
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(map, destinationRectangle: new Rectangle(0, 0, WindowWidth, WindowHeight),Color.White);
            burningStrikeFire.Draw(spriteBatch);
            burningStrikeLightning.Draw(spriteBatch);
            burningStrikeLight.Draw(spriteBatch);
            bigDaddy.Draw(spriteBatch);
            pc.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private static float Sigmoid(float currentValue, float maxValue, float lambda)
        {
            float range = maxValue * 2F;
            float result = ((range / (1F + ((float)System.Math.Exp((-currentValue * lambda))))) - maxValue);
            return result;
        }

    }
}
