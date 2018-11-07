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

namespace PLATFORMER1
{
    public class Player
    {
        public Sprite playerSprite = new Sprite();

        Game1 game = null;
        float runSpeed = 250f;
        float maxRunSpeed = 500f;
        float friction = 500f;
        float terminalVelocity = 500f;
        public float jumpStrength = 50000f;

        Collision collision = new Collision();

        SoundEffect jumpSound;
        SoundEffectInstance jumpSoundInstance;

        public Player()
        {

        }

        public void Load(ContentManager content, Game1 theGame)
        {
            playerSprite.Load(content, "hero", true);           

            game = theGame;
            playerSprite.velocity = Vector2.Zero;
            playerSprite.position = new Vector2(theGame.GraphicsDevice.Viewport.Width / 2, 0);
        }

        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
            playerSprite.UpdateHitBox();

            if (collision.IsColliding(playerSprite, game.goal.chestSprite))
            {
                game.Exit();
            }

            for (int i = 0; i < game.enemies.Count; i++)
            {
                playerSprite = collision.CollideWithMonster(this, game.enemies[i], deltaTime, game);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch);
        }

        private void UpdateInput(float deltaTime)
        {
            bool wasMovingLeft = playerSprite.velocity.X < 0;
            bool wasMovingRight = playerSprite.velocity.X > 0;

            Vector2 localAcceleration = game.gravity;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) == true)
            {
                localAcceleration.X += -runSpeed;
                playerSprite.SetFlipped(true);
                playerSprite.Play();
            }
            else if (wasMovingLeft == true)
            {
                localAcceleration.X += friction;
                playerSprite.Pause();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) == true)
            {
                localAcceleration.X += runSpeed;
                playerSprite.SetFlipped(false);
                playerSprite.Play();
            }
            else if (wasMovingRight == true)
            {
                localAcceleration.X += -friction;
                playerSprite.Pause();
            }

            if (Keyboard.GetState().IsKeyUp(Keys.Left) == true && Keyboard.GetState().IsKeyUp(Keys.Right) == true)
            {
                playerSprite.Pause();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true && playerSprite.canJump == true)
            {
                playerSprite.canJump = false;
                localAcceleration.Y -= jumpStrength;
                jumpSoundInstance.Play();
            }

            playerSprite.velocity += localAcceleration * deltaTime;

            if (playerSprite.velocity.X > maxRunSpeed)
            {
                playerSprite.velocity.X = maxRunSpeed;
            }
            else if (playerSprite.velocity.X < -maxRunSpeed)
            {
                playerSprite.velocity.X = -maxRunSpeed;
            }

            if (wasMovingLeft && (playerSprite.velocity.X > 0) || wasMovingRight && (playerSprite.velocity.X < 0))
            {
                playerSprite.velocity.X = 0;
            }

            if (playerSprite.velocity.Y > terminalVelocity)
            {
                playerSprite.velocity.Y = terminalVelocity;
            }

            playerSprite.position += playerSprite.velocity * deltaTime;

            collision.game = game;
            playerSprite = collision.CollideWithPlatforms(playerSprite, deltaTime);
        }
    }
}