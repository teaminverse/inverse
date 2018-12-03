using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inverse
{
    class Background
    {
        public Sprite background = new Sprite();
        public Sprite paraBG = new Sprite();
        MainGame game = null;
        float scrollMove = -40f;
        float scrollMove2 = -60f;
        public void Load(ContentManager content, MainGame theGame)
        {
            background.Load(content, "BGflip", false);
            paraBG.Load(content, "BGflip2", false);
            game = theGame;

            AnimatedTexture bganimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            bganimation.Load(content, "BGflip", 1, 0);
            background.AddAnimation(bganimation, 0, 1);
            background.Pause();

            AnimatedTexture paraanimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            paraanimation.Load(content, "BGflip2", 1, 0);
            paraBG.AddAnimation(paraanimation, 0, 1);
            paraBG.Pause();
            background.velocity = Vector2.Zero;
            background.position = new Vector2(0, 0);
            paraBG.velocity = Vector2.Zero;
            paraBG.position = new Vector2(0, 0);
        }
        public void Update(float deltaTime)
        {
            background.velocity = new Vector2(scrollMove, 0);
            paraBG.velocity = new Vector2(scrollMove2, 0);
            background.position += background.velocity * deltaTime;
            paraBG.position += paraBG.velocity * deltaTime;
            background.Update(deltaTime);
            paraBG.Update(deltaTime);
            if (background.position.X < -737)
            {
                background.position.X = 736;
            }
            if (paraBG.position.X < -737)
            {
                paraBG.position.X = 736;
           }

        }
        public void Draw(SpriteBatch spriteBatch,MainGame game)
        {
            background.Draw(spriteBatch,game);
            paraBG.Draw(spriteBatch, game);
        }




    }
}
