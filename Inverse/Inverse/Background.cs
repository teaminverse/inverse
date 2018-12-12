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
        public Sprite background2 = new Sprite();
      
        MainGame game = null;
        float offsetPosition = 1473f;
        float scrollMove = -40f;
     
        public void Load(ContentManager content, MainGame theGame)
        {
            background.Load(content, "BGflip", false);
            background2.Load(content, "BGflip", false);

            game = theGame;

            AnimatedTexture bganimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            AnimatedTexture bganimation2 = new AnimatedTexture(Vector2.Zero, 0, 1, 1);

            bganimation.Load(content, "BGflip", 1, 0);
            bganimation2.Load(content, "BGflip", 1, 0);

            background.AddAnimation(bganimation, 0, 1);
            background2.AddAnimation(bganimation, 0, 1);

            background.Pause();
            background2.Pause();

            background.velocity = Vector2.Zero;
            background2.velocity = Vector2.Zero;

            background.position = new Vector2(0, 0);
            background2.position = new Vector2(offsetPosition, 0);

            background.isBackground = true;
            background2.isBackground = true; 

        }
        public void Update(float deltaTime)
        {
            background.velocity = new Vector2(scrollMove, 0);
            background2.velocity = new Vector2(scrollMove, 0);

            background.position += background.velocity * deltaTime;
            background2.position += background.velocity * deltaTime;

            background.Update(deltaTime);
            background2.Update(deltaTime);

            if (background.position.X < -offsetPosition - 1)
            {
                background.position.X = offsetPosition;
            }

            if (background2.position.X < -offsetPosition - 1)
            {
                background2.position.X = offsetPosition;
            }


        }
        public void Draw(SpriteBatch spriteBatch,MainGame game)
        {
            background.Draw(spriteBatch,game);
            background2.Draw(spriteBatch, game);

        }




    }
}
