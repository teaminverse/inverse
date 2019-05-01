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
    public class LargeObstacle
    {
        MainGame game = null;
        public Sprite smallObSprite = new Sprite();
        public Sprite mediumObSprite = new Sprite();
        public Sprite largeObSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            largeObSprite.Load(content, textureToLoad, false, true, 1);

            AnimatedTexture largeObAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);

            largeObAnimation.Load(content, textureToLoad, 1, 1);
            largeObSprite.AddAnimation(largeObAnimation, 0, 0);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            largeObSprite.velocity = new Vector2(largeObSprite.xSpeed, 0) * deltaTime;

            largeObSprite.position += largeObSprite.velocity * deltaTime; 

            largeObSprite.Update(deltaTime);
            largeObSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            largeObSprite.Draw(spriteBatch, game);
        }

    }
}