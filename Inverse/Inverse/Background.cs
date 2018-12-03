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

        MainGame game = null;
        float scrollMove = -40f;

        public void Load(ContentManager content, MainGame theGame)
        {
            background.Load(content, "BGflip", false);
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "BGflip", 1, 0);
            background.AddAnimation(animation, 0, 1);
            background.Pause();

            background.velocity = Vector2.Zero;
            background.position = new Vector2(0, 0);
        }
        public void Update(float deltaTime)
        {
            background.velocity = new Vector2(scrollMove, 0);

            background.position += background.velocity * deltaTime;

            background.Update(deltaTime);

            if (background.position.X < -737)
            {
                background.position.X = 736;
            }
        }
        public void Draw(SpriteBatch spriteBatch,MainGame game)
        {
            background.Draw(spriteBatch,game);
        }




    }
}
