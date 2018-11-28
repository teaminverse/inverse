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


        public Sprite BGscroll = new Sprite();

        MainGame game = null;
        float scrollMove = -40;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            BGscroll.Load(content, "BGflip", false);

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "BGflip", 1, 1);
            BGscroll.AddAnimation(animation, 0, 0);
            BGscroll.Pause();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            BGscroll.Draw(spriteBatch, game);
        }
        //public void Update(float deltaTime);
        //{
        //
        //}




    }
}
