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

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            AnimatedTexture portalAnimation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            portalAnimation.Load(content, game.myTexture, 1, 1);
            portalSprite.AddAnimation(portalAnimation, 0, 3);

            portalSprite.velocity = Vector2.Zero;
            portalSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, 196);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            portalSprite.velocity = new Vector2(game.xSpeed, 0) * deltaTime;

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
