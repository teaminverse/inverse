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

        Game1 game = null;
        public float jumpStrength = 50000f;

        //Collision collision = new Collision();

        public Player()
        {

        }

        public void Load(ContentManager content, Game1 theGame)
        {
            playerSprite.Load(content, "hero", true);           

            game = theGame;
            playerSprite.velocity = Vector2.Zero;
            //playerSprite.position = new Vector2(theGame.GraphicsDevice.Viewport.Width / 2, 0);
        }

        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
            playerSprite.UpdateHitBox();       
        }

        public void Draw(SpriteBatch spriteBatch, Game1 theGame)
        {
            playerSprite.Draw(spriteBatch, game);
            playerSprite.position = new Vector2(theGame.GraphicsDevice.Viewport.Width / 2, 0);
        }

        private void UpdateInput(float deltaTime)
        {
            Vector2 localAcceleration = game.gravity;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                localAcceleration.Y -= jumpStrength;
            }

            playerSprite.position += playerSprite.velocity * deltaTime;

            /*collision.game = game;
            playerSprite = collision.CollideWithPlatforms(playerSprite, deltaTime);*/
        }
    }
}