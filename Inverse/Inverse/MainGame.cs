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
        public Vector2 gravity = new Vector2(0, 1000);
        public Collisions collisions = new Collisions();
        public PlusScore plusScore = new PlusScore();
        Background background = new Background();
        Background background2 = new Background();
        Background2 background3 = new Background2();
        Background2 background4 = new Background2();
        public ItemSpawner itemSpawner = new ItemSpawner();

        public bool debug = false;

        public int playerFPS = 20;

        public bool staticObject = false;

        public float totalScore = 0.0f;
        public int counter = 1;

        public float gameSpeed = 20000;
        public float speedMultiplier = 1.2f;

        public bool animatedSprite = true; 

        SpriteFont arialFont;

        public int lives = 1;
        Texture2D heart = null;
        Texture2D phaser = null;
        Texture2D sloMo = null;
        Texture2D oneHitShield = null;
        Texture2D pub = null;
        public bool powerUp = false;
        public bool phaserPickUp = false;
        public bool sloMoPickUp = false;
        public bool oneHitShieldPickUp = false;
        public bool upsideDown = false;
        public bool portaPortalOn = false; 

        Song gameMusic; 

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

            graphics.PreferredBackBufferHeight = 524;
            graphics.PreferredBackBufferWidth = 920;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.Load(Content, this);
            platform.Load(Content, this);
            itemSpawner.Load(Content, this);
            background.Load(Content, this);
            background2.Load(Content, this);
            background2.background.position.X = 1474;

            background3.Load(Content, this);
            background4.Load(Content, this);
            background4.background.position.X = 1473;            

            arialFont = Content.Load<SpriteFont>("arial");
            heart = Content.Load<Texture2D>("Heart");
            phaser = Content.Load<Texture2D>("phaser");
            sloMo = Content.Load<Texture2D>("sloMo");
            oneHitShield = Content.Load<Texture2D>("oneHitShield");
            pub = Content.Load<Texture2D>("powerUpBox");

            AIE.StateManager.CreateState("SPLASH", new TitleScreen());
            AIE.StateManager.CreateState("GAME", new GameState());
            AIE.StateManager.CreateState("GAMEOVER", new GameOverState());

           // gameMusic = Content.Load<Song>("Inverse mp3");
           // MediaPlayer.Play(gameMusic);
        }

        protected override void UnloadContent()
        {

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

            totalScore += (float)gameTime.ElapsedGameTime.TotalSeconds;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            player.Update(deltaTime);
            platform.Update(deltaTime);
            itemSpawner.Update(deltaTime);
            background.Update(deltaTime);
            background2.Update(deltaTime);
            background3.Update(deltaTime);
            background4.Update(deltaTime);


            if (itemSpawner.spawnedItems.Count > 0)
            {
                foreach (Item item in itemSpawner.spawnedItems)
                {
                    item.Update(deltaTime); 
                    {
                        return;
                    }
                }
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            spriteBatch.Begin();

            background.Draw(spriteBatch, this);
            background2.Draw(spriteBatch, this);
            background3.Draw(spriteBatch, this);
            background4.Draw(spriteBatch, this);
            player.Draw(spriteBatch);
            platform.Draw(spriteBatch);

            if (itemSpawner.spawnedItems.Count > 0)
            {
                foreach (Item item in itemSpawner.spawnedItems)
                {
                    item.Draw(spriteBatch);
                }
            }


            if (debug == true)
            {
                spriteBatch.DrawString(arialFont, "Debug = " + debug.ToString(), new Vector2(20, 40), Color.Red);
            }

            int loopCount = 0;
            while (loopCount < lives)
            {
                spriteBatch.Draw(heart, new Vector2(GraphicsDevice.Viewport.Width - 60 - loopCount * 40, 20), Color.White);
                loopCount++;
            }

            spriteBatch.Draw(pub, new Vector2(GraphicsDevice.Viewport.Width - 100, 380), Color.White);

            if (powerUp == false && phaserPickUp == true)
            {
                spriteBatch.Draw(phaser, new Vector2(GraphicsDevice.Viewport.Width - 80, 400), Color.White);
                powerUp = true;
            }

            if (powerUp == false && sloMoPickUp == true)
            {
                spriteBatch.Draw(sloMo, new Vector2(GraphicsDevice.Viewport.Width - 80, 400), Color.White);
                powerUp = true;
            }

            if (powerUp == false && oneHitShieldPickUp == true) 
            {
                spriteBatch.Draw(oneHitShield, new Vector2(GraphicsDevice.Viewport.Width - 80, 400), Color.White);
                powerUp = true;
            }

            spriteBatch.DrawString(arialFont, "SCORE: " + (int)AddToScore(), new Vector2(20, 20), Color.LightBlue);
            spriteBatch.DrawString(arialFont, "SpawnTimer: " + (int)itemSpawner.spawnTimer, new Vector2(20, 50), Color.LightBlue);


            spriteBatch.End();

            AIE.StateManager.Draw(spriteBatch);

            base.Draw(gameTime);
        }
        private float AddToScore()
        {
            totalScore += 0.15f;
            if (collisions.IsColliding(player.playerSprite, plusScore.plusScoreSprite))
            {
                totalScore += 200;
            }
            return totalScore;
        }
    }
}
