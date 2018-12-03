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
    public class Extra_Life
    {
        public Sprite extraLifeSprite = new Sprite();
        Collisions collision = new Collisions();
        MainGame game = null;
        float extraLifeSpeed = -440;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            extraLifeSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, 200);

            extraLifeSprite.Load(content, "extraLife", false);

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "extraLife", 1, 1);
            extraLifeSprite.AddAnimation(animation, 0, 0);
            extraLifeSprite.Pause();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            extraLifeSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            extraLifeSprite.velocity = new Vector2(extraLifeSpeed, 0) * deltaTime;
            extraLifeSprite.position += extraLifeSprite.velocity * deltaTime;

            extraLifeSprite.Update(deltaTime);
            extraLifeSprite.UpdateHitBox();

        }
    }
}
