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
    class One_Hit_Shield
    {
        public Sprite oneHitShieldSprite = new Sprite();
        Collisions collision = new Collisions();
        MainGame game = null;
        float oneHitShieldSpeed = 0;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "oneHitShield", 1, 1);

            oneHitShieldSprite.AddAnimation(animation, 0, 3);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            oneHitShieldSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            oneHitShieldSprite.velocity = new Vector2(oneHitShieldSpeed, 0) * deltaTime;
            oneHitShieldSprite.position += oneHitShieldSprite.velocity * deltaTime;

            //obstacleSprite.UpdateHitbox();

        }
    }
}
