using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Inverse
{
    public class LargeOb
    {
        public Obstacle obstacle = new Obstacle();
        public void Load(ContentManager content, MainGame game)
        {
            myTexture = "";
            speed = 34;

            obstacle.Load(content, game);
        }

        public void Update(float deltaTime)
        {
            obstacle.Update(deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            obstacle.Draw(spriteBatch);
        }
    }
}
