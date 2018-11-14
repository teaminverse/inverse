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
    public class Obstacle
    {
        public Sprite obstacleSprite = new Sprite();
        //Collision collision = new Collision();
        Game1 game = null;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;

            obstacleSprite.position = new Vector2(0, game.GraphicsDevice.Viewport.Height / 2);

            obstacleSprite.Load(content, "Obstacle", true);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            obstacleSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            //collision.game = game;
            obstacleSprite.Update(deltaTime);
            obstacleSprite.UpdateHitBox();
        }

    }
}