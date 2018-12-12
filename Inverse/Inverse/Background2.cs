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
    class Background2
    {
        public Sprite paraBG = new Sprite();
        public Sprite paraBG2 = new Sprite();

        MainGame game = null;

        float offsetPosition = 737;
        float scrollMove2 = -60f;

        float vertOffset = 20f;

        public void Load(ContentManager content, MainGame theGame)
        {
          
            paraBG.Load(content, "BGflip2", false);
            paraBG2.Load(content, "BGflip2", false);

            game = theGame;

            AnimatedTexture paraanimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            AnimatedTexture paraanimation2 = new AnimatedTexture(Vector2.Zero, 0, 1, 1);

            paraanimation.Load(content, "BGflip2", 1, 0);
            paraanimation2.Load(content, "BGflip2", 1, 0);

            paraBG.AddAnimation(paraanimation);
            paraBG2.AddAnimation(paraanimation);

            paraBG.Pause();
            paraBG2.Pause();

            paraBG.velocity = Vector2.Zero;
            paraBG2.velocity = Vector2.Zero;

            paraBG.position = new Vector2(0, vertOffset);
            paraBG2.position = new Vector2(offsetPosition, vertOffset);

            paraBG.isBackground = true;
            paraBG2.isBackground = true; 

        }
        public void Update(float deltaTime)
        {
           
            paraBG.velocity = new Vector2(scrollMove2, 0);
            paraBG2.velocity = new Vector2(scrollMove2, 0);

            paraBG.position += paraBG.velocity * deltaTime;
            paraBG2.position += paraBG.velocity * deltaTime;

            paraBG.Update(deltaTime);
            paraBG2.Update(deltaTime);

            if (paraBG.position.X < -offsetPosition - 1)
            {
                paraBG.position.X = offsetPosition;
            }

            if (paraBG2.position.X < -offsetPosition - 1)
            {
                paraBG2.position.X = offsetPosition;
            }

        }
        public void Draw(SpriteBatch spriteBatch, MainGame game)
        {
            paraBG.Draw(spriteBatch, game);
            paraBG2.Draw(spriteBatch, game);
        }




    }
}
