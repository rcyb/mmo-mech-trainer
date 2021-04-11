using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MmoMechTrainer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;

        Texture2D bigDaddy;
        Texture2D pc;
        Texture2D map;
        private const int WindowWidth = 800;
        private const int WindowHeight = 800;

        Vector2 pcPosition;
        Vector2 pcSize;
        float pcRotation;

        float bigDaddyRotation;
        Vector2 bigDaddyPosition;
        Vector2 bigDaddySize;


        int beforeMechanicTimer;
        Texture2D burntStrike;
        Vector2 burntStrikePosition;
        float burntStrikeRotation;
        int burntStrikeWidth;
        int burntStrikeHeight;
        bool isAtPosition;
        bool isfirstPhase;
        int firstPhaseCounter;
        bool isSecondPhase;
        int secondPhaseCounter;
        float burntStrikeOpacity;
        bool isOver;
        bool isFired;




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


            pcPosition = new Vector2(WindowWidth / 2F, WindowHeight / 2F);
            pcSize = new Vector2(50, 50);
            pcRotation = 0.0F;
            
            bigDaddyPosition = new Vector2(WindowWidth / 2F + new System.Random().Next(-150,150), WindowHeight / 2F + new System.Random().Next(-150,150));
            bigDaddySize = new Vector2(150, 150);
            bigDaddyRotation = 0.0F;


            burntStrikePosition = new Vector2(WindowWidth / 2F, WindowHeight / 2F);
            burntStrikeRotation = bigDaddyRotation;
            burntStrikeWidth = 250;
            burntStrikeHeight = 2000;
            burntStrikeOpacity = 0.0F;

            beforeMechanicTimer = 100;
            isAtPosition = false;
            isfirstPhase = false;
            firstPhaseCounter = 200;
            
            isSecondPhase = false;
            secondPhaseCounter = 100;
            isOver = false;
            isFired = false;


            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = this.Content.Load<Texture2D>("Images/Maps/map");
            pc = this.Content.Load<Texture2D>("Images/Classes/sch");
            bigDaddy = this.Content.Load<Texture2D>("Images/Enemies/dadcred");
            burntStrike = new Texture2D(GraphicsDevice, 1, 1);
            burntStrike.SetData(new[] { new Color(0,0,255) });
        }

        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                KeyboardState state = Keyboard.GetState();
                
                if (state.IsKeyDown(Keys.Escape))
                    Exit();
                if (state.IsKeyDown(Keys.Right))
                    pcPosition.X += 5;
                if (state.IsKeyDown(Keys.Left))
                    pcPosition.X -= 5;
                if (state.IsKeyDown(Keys.Up))
                    pcPosition.Y -= 5;
                if (state.IsKeyDown(Keys.Down))
                    pcPosition.Y += 5;

                if (pcPosition.X > this.GraphicsDevice.Viewport.Width)
                    pcPosition.X = 0;
                if (pcPosition.X < 0)
                    pcPosition.X = this.GraphicsDevice.Viewport.Width;
                if (pcPosition.Y > this.GraphicsDevice.Viewport.Height)
                    pcPosition.Y = 0;
                if (pcPosition.Y < 0)
                    pcPosition.Y = this.GraphicsDevice.Viewport.Height;


                Vector2 diff = burntStrikePosition - bigDaddyPosition;

                
                if (!bigDaddyPosition.Equals(burntStrikePosition) && !isAtPosition)
                {
                    
                    bigDaddyPosition.X += diff.X/(System.Math.Abs(diff.X) < 1 ? 1 : 10 );
                    bigDaddyPosition.Y += diff.Y/(System.Math.Abs(diff.Y) < 1 ? 1 : 10 );
                }
                else {
                    isAtPosition = true;
                    isfirstPhase = true;
                }

                if (isAtPosition)
                {

                }


                if (isfirstPhase)
                {
                    if (firstPhaseCounter < 50 && !isFired)
                    {
                        burntStrikeOpacity = 1.0F;
                        isFired = true;
                    }
                    burntStrikeOpacity = burntStrikeOpacity -  0.01F;
                    Debug.WriteLine(burntStrikeOpacity);
                    if (firstPhaseCounter == 0)
                    {
                        isfirstPhase = false;
                        isSecondPhase = true;
                    }
                    firstPhaseCounter -= 1;
                }

                if (isSecondPhase)
                {
                    

                    secondPhaseCounter -= 1;
                }






                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            spriteBatch.Begin(SpriteSortMode.FrontToBack);
            spriteBatch.Draw(map, destinationRectangle: new Rectangle(0, 0, WindowWidth, WindowHeight),Color.White);
            spriteBatch.Draw(burntStrike, destinationRectangle: new Rectangle((int)bigDaddyPosition.X - burntStrikeWidth / 2, (int)bigDaddyPosition.Y - burntStrikeHeight / 2, burntStrikeWidth, burntStrikeHeight), null, new Color(0,0,255,burntStrikeOpacity), burntStrikeRotation, new Vector2(burntStrike.Width / 2, burntStrike.Height / 2), SpriteEffects.None, 0.5F);
            spriteBatch.Draw(bigDaddy, destinationRectangle: new Rectangle((int)bigDaddyPosition.X , (int)bigDaddyPosition.Y, (int)bigDaddySize.X, (int)bigDaddySize.Y),null, Color.White,bigDaddyRotation,new Vector2(bigDaddy.Width/2,bigDaddy.Height/2),SpriteEffects.None,1.0F);
            spriteBatch.Draw(pc, destinationRectangle: new Rectangle((int)pcPosition.X, (int)pcPosition.Y, (int)pcSize.X, (int)pcSize.Y), null, Color.White, pcRotation, new Vector2(pc.Width / 2, pc.Height / 2), SpriteEffects.None, 0.5F);
           
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
