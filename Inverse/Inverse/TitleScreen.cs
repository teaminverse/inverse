using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;



namespace Inverse
{
    public class TitleScreen : AIE.State
    {
        SpriteFont font = null;
        float timer = 3;

        public GraphicsDevice graphicsDevice;
        GraphicsDeviceManager graphics;


        public TitleScreen() : base()
        {
        }
        public void initialize(Texture2D texture, Vector2 position, ContentManager Content)
        {
            
            
            
        }
        public override void Update(ContentManager content, GameTime gameTime)
        {
            if (font == null)
            {
                font = content.Load<SpriteFont>("Arial");
            }
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                AIE.StateManager.ChangeState("GAME");
                timer = 3;
            }
            Console.ReadKey();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
          
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Inverse",
            new Vector2(200, 200), Color.White);

            spriteBatch.End();
           
        }
        public override void CleanUp()
        {
            font = null;
            timer = 3;
        }
    }
}
