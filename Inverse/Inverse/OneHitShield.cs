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
    public class OneHitShield
    {
        MainGame game = null;

        public Sprite oneHitShieldSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            oneHitShieldSprite.Load(content, textureToLoad, false, true, 1);

            AnimatedTexture oneHitShieldAnimation = new AnimatedTexture(oneHitShieldSprite.offset, 0, 1, 1);

            oneHitShieldAnimation.Load(content, textureToLoad, 1, 1);
            oneHitShieldSprite.AddAnimation(oneHitShieldAnimation, 0, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            oneHitShieldSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            oneHitShieldSprite.Update(deltaTime);
            oneHitShieldSprite.UpdateHitBox();
        }

    }
}
