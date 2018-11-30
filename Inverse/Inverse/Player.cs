using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Inverse
{
    public class Player
    {
        public Sprite playerSprite = new Sprite();
        public bool gravDown = true;
        MainGame game = null;
        public float jumpStrength = 25000f;

        Collisions collision = new Collisions();

        public Player()
        {

        }

        public void Load(ContentManager content, MainGame theGame)
        {
            playerSprite.Load(content, "hero", true);

            AnimatedTexture animation = new AnimatedTexture(playerSprite.offset, 0, 1, 1);
            animation.Load(content, "walk", 12, 20);
           // animation.Load(content, "Jump (spritesheet)", 10, 30);
            playerSprite.AddAnimation(animation, 0, -5);
            playerSprite.Play();

            game = theGame;
            playerSprite.velocity = Vector2.Zero;
            playerSprite.position = new Vector2(50, 150);
        }

        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
            playerSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch, game);
        }

        private void UpdateInput(float deltaTime)
        {
            if (collision.IsColliding(playerSprite, game.platform.platformSprite) == true)
            {
                playerSprite.Play();
            }
            else
            {
                playerSprite.Pause();
            }

            if(playerSprite.gravDown == true)
            {
                playerSprite = collision.CollideBelowPortal(playerSprite, game.portal.portalSprite, deltaTime);
                playerSprite = collision.CollideBelow(playerSprite, game.platform.platformSprite, deltaTime);

                Vector2 localAcceleration = game.gravity;

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && playerSprite.canJump == true)
                {
                    playerSprite.canJump = false;
                    localAcceleration.Y -= jumpStrength;
                }

                playerSprite.velocity += localAcceleration * deltaTime;               
                playerSprite.position += playerSprite.velocity * deltaTime;
            }
            else
            {
                playerSprite = collision.CollideAbovePortal(playerSprite, game.portal.portalSprite, deltaTime);
                playerSprite = collision.CollideAbove(playerSprite, game.platform.platformSprite, deltaTime);
                Vector2 localAcceleration = -game.gravity;

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && playerSprite.canJump == true)

                {
                    playerSprite.canJump = false;
                    localAcceleration.Y += jumpStrength;

                }

                playerSprite.velocity += localAcceleration * deltaTime;
                playerSprite.position += playerSprite.velocity * deltaTime;
            }

        }
    }
}