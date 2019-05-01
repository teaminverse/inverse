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
    public class PlusScore
    {
        MainGame game = null;

        public Sprite plusScoreSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;
            AnimatedTexture plusScoreAnimation = new AnimatedTexture(plusScoreSprite.offset, 0, 1, 1);

            plusScoreAnimation.Load(content, textureToLoad, 1, 1);
            plusScoreSprite.AddAnimation(plusScoreAnimation, 0, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            plusScoreSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            plusScoreSprite.velocity = new Vector2(plusScoreSprite.xSpeed, 0) * deltaTime;

            plusScoreSprite.position += plusScoreSprite.velocity * deltaTime;

            plusScoreSprite.Update(deltaTime);
            plusScoreSprite.UpdateHitBox();
        }
    }
}
