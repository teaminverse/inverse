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
        Background2 foreground = new Background2();

        public ItemSpawner itemSpawner = new ItemSpawner();

        public bool debug = false;

        public int playerFPS = 20;

        public bool staticObject = false;

        public float totalScore = 0f;
        public int counter = 1;

        public float gameSpeed = 20000;
        public float speedMultiplier = 1.2f; 

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

        Song gameMusic;

        public Texture2D intro;
        public Texture2D instruction; 
        public Vector2 introPos;

        const int STATE_SPLASH = 0;
        const int STATE_INSTRUCTION = 1;
        const int STATE_GAME = 2;
        public const int STATE_GAMEOVER = 3;

        public int gameState = STATE_SPLASH;

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
            foreground.Load(Content, this);
        

            arialFont = Content.Load<SpriteFont>("arial");
            heart = Content.Load<Texture2D>("Heart");
            phaser = Content.Load<Texture2D>("phaser");
            sloMo = Content.Load<Texture2D>("sloMo");
            oneHitShield = Content.Load<Texture2D>("oneHitShield");
            pub = Content.Load<Texture2D>("powerUpBox");

            intro = Content.Load<Texture2D>("titlescreen");
            instruction = Content.Load<Texture2D>("Heart"); 
            introPos.X = 30;
            introPos.Y = 30;

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

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            switch (gameState)
            {
                case STATE_SPLASH:
                    UpdateSplashState(deltaTime);
                    break;
                case STATE_INSTRUCTION:
                    UpdateInstructionState(deltaTime);
                    break;
                case STATE_GAME:
                    UpdateGameState(deltaTime);
                    break;
                case STATE_GAMEOVER:
                    UpdateGameOverState(deltaTime);
                    break;
            }

        }

        private void UpdateSplashState(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.RightShift))
            {
                gameState = STATE_INSTRUCTION;
            }
        }
        private void UpdateInstructionState(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                gameState = STATE_GAME;
            }
        }


        private void UpdateGameState(float deltaTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                debug = true;
            }
            else if (Keyboard.GetState().IsKeyUp(Keys.F1))
            {
                debug = false;
            }

            totalScore += deltaTime;


            player.Update(deltaTime);
            platform.Update(deltaTime);
            itemSpawner.Update(deltaTime);

            background.Update(deltaTime);
            foreground.Update(deltaTime);



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

        private void UpdateGameOverState(float deltaTime)
        {
            itemSpawner.spawnedItems.Clear();
            totalScore = 0;
            powerUp = false; 
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                gameState = STATE_SPLASH;

            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            spriteBatch.Begin();

            switch (gameState)
            {
                case STATE_SPLASH:
                    DrawSplashState(spriteBatch);
                    break;
                case STATE_INSTRUCTION:
                    DrawInstructionState(spriteBatch);
                    break;
                case STATE_GAME:
                    DrawGameState(spriteBatch);
                    break;
                case STATE_GAMEOVER:
                    DrawGameOverState(spriteBatch);
                    break;
            }
           
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawSplashState(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(intro, new Rectangle(0, 0, 920, 524), Color.White);
            spriteBatch.DrawString(arialFont, "Press enter to Play!", new Vector2(350, 20), Color.Black);
        }

        private void DrawInstructionState(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(instruction, new Rectangle(0, 0, 920, 542), Color.White);
        }


        private void DrawGameState(SpriteBatch spriteBatch)
        {

            background.Draw(spriteBatch, this);
            foreground.Draw(spriteBatch, this);

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
                spriteBatch.Draw(phaser, new Vector2(GraphicsDevice.Viewport.Width - 75, 405), Color.White);
                spriteBatch.DrawString(arialFont, "Phaser: " + (int)player.phaseTimer, new Vector2(GraphicsDevice.Viewport.Width - 200, 405), Color.LightBlue);
            }

            if (powerUp == false && sloMoPickUp == true)
            {
                spriteBatch.Draw(sloMo, new Vector2(GraphicsDevice.Viewport.Width - 75, 405), Color.White);
                spriteBatch.DrawString(arialFont, "SloMo: " + (int)player.sloMoTimer, new Vector2(GraphicsDevice.Viewport.Width - 200, 405), Color.LightBlue);
            }

            spriteBatch.DrawString(arialFont, "SCORE: " + (int)AddToScore(), new Vector2(20, 20), Color.LightBlue);
        }

        private void DrawGameOverState(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(arialFont, "Game Over... :(", new Vector2(200, 200), Color.White);
            spriteBatch.DrawString(arialFont, "Press space to continue!", new Vector2(200, 240), Color.White);
        }

        private float AddToScore()
        {
            if (gameState == 1f)
            {
                totalScore += 0.15f;
            }
            return totalScore;
        }
    }
}
