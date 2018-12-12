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
        public Sprite background = new Sprite();
        public Sprite paraBG = new Sprite();
        MainGame game = null;
        
        float scrollMove2 = -60f;
        public void Load(ContentManager content, MainGame theGame)
        {
          
            paraBG.Load(content, "BGflip2", false);
            game = theGame;


            AnimatedTexture paraanimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            paraanimation.Load(content, "BGflip2", 1, 0);
            paraBG.AddAnimation(paraanimation, 0, 1);
            paraBG.Pause();
           
            paraBG.velocity = Vector2.Zero;
            paraBG.position = new Vector2(0, 0);

            paraBG.isBackground = true;
        }
        public void Update(float deltaTime)
        {
           
            paraBG.velocity = new Vector2(scrollMove2, 0);
       
            paraBG.position += paraBG.velocity * deltaTime;
         
            paraBG.Update(deltaTime);
           
            if (paraBG.position.X < -737)
            {
                paraBG.position.X = 736;
            }

        }
        public void Draw(SpriteBatch spriteBatch, MainGame game)
        {
           
            paraBG.Draw(spriteBatch, game);
        }




    }
}
