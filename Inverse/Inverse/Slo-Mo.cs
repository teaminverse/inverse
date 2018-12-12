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
    public class Slo_Mo
    {
        MainGame game = null;

        public Sprite sloMoSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null; 

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            sloMoSprite.Load(content, textureToLoad, false, true, 1);

            AnimatedTexture sloMoAnimation = new AnimatedTexture(sloMoSprite.offset, 0, 1, 1);

            sloMoAnimation.Load(content, textureToLoad, 1, 1);
            sloMoSprite.AddAnimation(sloMoAnimation, 0, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sloMoSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            sloMoSprite.velocity = new Vector2(sloMoSprite.xSpeed, 0) * deltaTime;

            sloMoSprite.position += sloMoSprite.velocity * deltaTime;

            sloMoSprite.Update(deltaTime);
            sloMoSprite.UpdateHitBox();
        }
    }
}
