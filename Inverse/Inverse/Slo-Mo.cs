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
    class Slo_Mo
    {
        public Sprite sloMoSprite = new Sprite();
        Collisions collision = new Collisions();
        MainGame game = null;
        float sloMo = 0;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "sloMo", 1, 1);

            sloMoSprite.AddAnimation(animation, 0, 3);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sloMoSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

           // sloMoSprite.velocity = new Vector2(sloMoSpeed, 0) * deltaTime;
            sloMoSprite.position += sloMoSprite.velocity * deltaTime;

            //obstacleSprite.UpdateHitbox();

        }
    }
}
