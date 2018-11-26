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
        Collisions collision = new Collisions();
        MainGame game = null;
        float obstacleSpeed = 400f;
        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "obstacle", 1, 1);

            obstacleSprite.AddAnimation(animation, 0, 3);

            obstacleSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, 200);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           obstacleSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
           collision.game = game;

            obstacleSprite.velocity = new Vector2(obstacleSpeed, 0) * deltaTime;
            obstacleSprite.position += obstacleSprite.velocity * deltaTime;

            obstacleSprite.Update(deltaTime);
            obstacleSprite.UpdateHitBox();


        }

    }
}