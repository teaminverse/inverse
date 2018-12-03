using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Inverse
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player();
        public Platform platform = new Platform();
        public Portal portal = new Portal();
        public Vector2 gravity = new Vector2(0, 1000);
        Background background = new Background();
        Background background2 = new Background();
        public LevelGenerator levelGenerator = new LevelGenerator();
        public ArrayList spawnedObjects = new ArrayList();

        SpriteFont arialFont;


        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 730;
            graphics.PreferredBackBufferWidth = 600;
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
            levelGenerator.Load(Content, this);
            background.Load(Content, this);
            background2.Load(Content, this);
            background2.background.position.X = 737;

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

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            player.Update(deltaTime);
            platform.Update(deltaTime);
            portal.Update(deltaTime);
            levelGenerator.Update(deltaTime);
            background.Update(deltaTime);
            background2.Update(deltaTime);

            foreach (object o in this.spawnedObjects)
            {
                if (o is Obstacle)
                {
                    Obstacle thisoObstacle = (Obstacle)o;
                }

                AIE.StateManager.Update(Content, gameTime);

                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);
            
            spriteBatch.Begin();
            background.Draw(spriteBatch, this);
            background2.Draw(spriteBatch, this);
            player.Draw(spriteBatch);
            platform.Draw(spriteBatch);
            portal.Draw(spriteBatch);
            
            spriteBatch.End();

            AIE.StateManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
