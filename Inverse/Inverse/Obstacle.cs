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
    public class Obstacle
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

            AnimatedTexture smallObAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            AnimatedTexture medObAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            AnimatedTexture largeObAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);

            smallObAnimation.Load(content, textureToLoad, 1, 1);
            smallObSprite.AddAnimation(smallObAnimation, 0, 0);

            medObAnimation.Load(content, textureToLoad, 1, 1);
            mediumObSprite.AddAnimation(medObAnimation, 0, 0);

            largeObAnimation.Load(content, textureToLoad, 1, 1);
            largeObSprite.AddAnimation(largeObAnimation, 0, 0);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            smallObSprite.velocity = new Vector2(smallObSprite.xSpeed, 0) * deltaTime;
            mediumObSprite.velocity = new Vector2(mediumObSprite.xSpeed, 0) * deltaTime;
            largeObSprite.velocity = new Vector2(largeObSprite.xSpeed, 0) * deltaTime;

            smallObSprite.position += smallObSprite.velocity * deltaTime;
            mediumObSprite.position += mediumObSprite.velocity * deltaTime;
            largeObSprite.position += largeObSprite.velocity * deltaTime; 

            smallObSprite.Update(deltaTime);
            smallObSprite.UpdateHitBox();
            mediumObSprite.Update(deltaTime);
            mediumObSprite.UpdateHitBox();
            largeObSprite.Update(deltaTime);
            largeObSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            smallObSprite.Draw(spriteBatch, game);
            mediumObSprite.Draw(spriteBatch, game);
            largeObSprite.Draw(spriteBatch, game);
        }

    }
}