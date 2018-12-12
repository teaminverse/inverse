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
    public class SmallObstacle
    {
        MainGame game = null;

        public Sprite smallObSprite = new Sprite();

        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            smallObSprite.Load(content, textureToLoad, false, true, 1);

            AnimatedTexture smallObAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);

            smallObAnimation.Load(content, textureToLoad, 1, 1);
            smallObSprite.AddAnimation(smallObAnimation, 0, 0);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            smallObSprite.velocity = new Vector2(smallObSprite.xSpeed, 0) * deltaTime;

            smallObSprite.position += smallObSprite.velocity * deltaTime;

            smallObSprite.Update(deltaTime);
            smallObSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smallObSprite.Draw(spriteBatch, game);
        }
    }
}
