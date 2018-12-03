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
        MainGame game = null;
        public Sprite obstacleSprite = new Sprite();
        Collisions collision = new Collisions();
        float obstacleSpeed = 400f;

        public string myTexture;

        public float xSpeed = 0;
        
        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, myTexture, 1, 1);
            obstacleSprite.AddAnimation(animation, 0, 3);

            obstacleSprite.velocity = Vector2.Zero; 
            obstacleSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, 200);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            obstacleSprite.velocity = new Vector2(xSpeed, 0) * deltaTime;

            obstacleSprite.position += obstacleSprite.velocity * deltaTime;

            obstacleSprite.Update(deltaTime);
            obstacleSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            obstacleSprite.Draw(spriteBatch, game);
        }

    }
}