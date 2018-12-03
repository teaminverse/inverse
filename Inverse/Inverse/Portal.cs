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
        public Sprite portalSprite = new Sprite();
        Collisions collision = new Collisions();
        MainGame game = null;
        public float portalSpeed = -20000;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            portalSprite.Load(content, "Portal", false);
            portalSprite.velocity = new Vector2(-300, 0);
            portalSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, 196);
            portalSprite.UpdateHitBox();
          
            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "Portal", 1, 1);
            portalSprite.AddAnimation(animation, 0, 0);
            portalSprite.Pause();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            portalSprite.Draw(spriteBatch, game);
            // Random generation off screen moving into view
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            portalSprite.velocity = new Vector2(portalSpeed, 0) * deltaTime;
            portalSprite.position += portalSprite.velocity * deltaTime;

            portalSprite.Update(deltaTime);
            portalSprite.UpdateHitBox();

        }

    }
}
