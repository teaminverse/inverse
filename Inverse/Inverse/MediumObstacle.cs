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
    public class MediumObstacle
    {
        MainGame game = null;
    
        public Sprite mediumObSprite = new Sprite();

        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            AnimatedTexture medObAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);

            medObAnimation.Load(content, textureToLoad, 1, 1);
            mediumObSprite.AddAnimation(medObAnimation, 0, 0);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            mediumObSprite.velocity = new Vector2(mediumObSprite.xSpeed, 0) * deltaTime;

            mediumObSprite.position += mediumObSprite.velocity * deltaTime;

            mediumObSprite.Update(deltaTime);
            mediumObSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mediumObSprite.Draw(spriteBatch, game);
        }
    }

}
