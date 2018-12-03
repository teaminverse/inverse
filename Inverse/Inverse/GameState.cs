using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Inverse
{
    public class GameState : AIE.State
    {
        public Vector2 gravity = new Vector2(0, 1000);

        SpriteFont font = null;

        bool isLoaded = false;

        public GameState() : base()
        {
        }
        public override void Update(ContentManager content, GameTime gameTime)
        {
            if (isLoaded == false)
            {
                isLoaded = true;
                font = content.Load<SpriteFont>("Arial");
            }

            /*if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                AIE.StateManager.ChangeState("GAMEOVER");
            }*/
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Game State",
            new Vector2(200, 200), Color.White);
            spriteBatch.End();
        }
        public override void CleanUp()
        {
            font = null;
            isLoaded = false;
        }
    }
}
