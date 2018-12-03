using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Inverse
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public bool debug = false;

        Player player = new Player();
        Collisions collisions = new Collisions();
        Extra_Life exLife = new Extra_Life();
       
        public Platform platform = new Platform();
        public Portal portal = new Portal();
        public Vector2 gravity = new Vector2(0, 1000);
        //Background background = new Background();
        public Obstacle obstacle = new Obstacle();
        public ObstacleSpawner obstacleSpawner = new ObstacleSpawner();
        
        public bool staticObject = false; 

        public float totalScore = 0.0f;
        public int counter = 0;

        public SpriteFont arialFont;

        public Texture2D rect;

        public void DrawRectangle(Rectangle coords, Color color)
        {
            if (rect == null)
            {
                rect = new Texture2D(GraphicsDevice, 1, 1);
                rect.SetData(new[] { Color.White });
            }
            spriteBatch.Draw(rect, coords, color);
        }

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
             
            player.Load(Content, this);
            platform.Load(Content, this);
            portal.Load(Content, this);
            //background.Load(Content, this);
            obstacleSpawner.Load(Content, this);
            

            arialFont = Content.Load<SpriteFont>("arial");

            AIE.StateManager.CreateState("SPLASH", new TitleScreen());
            AIE.StateManager.CreateState("GAME", new GameState());
            AIE.StateManager.CreateState("GAMEOVER", new GameOverState());

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                debug = true;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.F1))
            {
                debug = false;
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            totalScore += (float)gameTime.ElapsedGameTime.TotalSeconds;
      
            player.Update(deltaTime);
            platform.Update(deltaTime);
            portal.Update(deltaTime);
            obstacleSpawner.Update(deltaTime);
           // background.Update(deltaTime);

           // Run the Update function for each obstacle inside of our spawned obstacles array 
            foreach (Obstacle obstacle in obstacleSpawner.spawnedObstacles)
            {
                obstacle.Update(deltaTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            platform.Draw(spriteBatch);
            //background.Draw(spriteBatch);
            portal.Draw(spriteBatch);

            // Run the Draw function for each obstacle inside of our spawned obsatcles array
            foreach (Obstacle obstacle in obstacleSpawner.spawnedObstacles)
            {
                obstacle.Draw(spriteBatch);
            }

            spriteBatch.DrawString(arialFont, "SCORE: " + AddToScore(), new Vector2(20, 20), Color.LightBlue);

            if (debug == true)
            {
                spriteBatch.DrawString(arialFont, "Debug = " + debug.ToString(), new Vector2(20, 40), Color.Red);
            }
            
            spriteBatch.End();

            AIE.StateManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        private string AddToScore()
        {
            totalScore +=0.15f;
            if (collisions.IsColliding(player.playerSprite, exLife.extraLifeSprite))
            {
                totalScore += 200;
            }
            return totalScore.ToString();
        }
    }
}
