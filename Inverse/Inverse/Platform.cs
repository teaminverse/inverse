using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Inverse
{
    public class Platform
    {
        public Sprite platformSprite = new Sprite();
        Collisions collision = new Collisions();
        MainGame game = null;
        public Vector2 platform = new Vector2(0, 0);

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            platformSprite.Load(content, "Platform (test)", true );
            

            AnimatedTexture animation = new AnimatedTexture(platformSprite.offset, 0, 1, 1);
            animation.Load(content, "walk (1)", 12, 20);
            platformSprite.AddAnimation(animation, 0, -5);
            platformSprite.Play();
            //playerSprite.Pause();

            game = theGame;
            platformSprite.velocity = Vector2.Zero;
            platformSprite.position = new Vector2(0, game.GraphicsDevice.Viewport.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            platformSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            platformSprite.Update(deltaTime);
            platformSprite.UpdateHitBox();
        }
    }
}
