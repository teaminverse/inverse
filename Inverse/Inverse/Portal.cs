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
    public class Portal
    {
        MainGame game = null;
        public Sprite portalSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            portalSprite.Load(content, textureToLoad, false, true, 12);

            AnimatedTexture portalAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
             portalAnimation.Load(content, textureToLoad, 12, 12);
             portalSprite.AddAnimation(portalAnimation, 0, 0);

            portalSprite.velocity = Vector2.Zero;
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            portalSprite.velocity = new Vector2(portalSprite.xSpeed, 0) * deltaTime;

            portalSprite.position += portalSprite.velocity * deltaTime;

            portalSprite.Update(deltaTime);
            portalSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            portalSprite.Draw(spriteBatch, game);
        }

    }
}
