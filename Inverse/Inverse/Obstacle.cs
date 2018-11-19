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
        Game1 game = null;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "obstacle", 1, 1);

            obstacleSprite.AddAnimation(animation, 0, 3);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           obstacleSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
           collision.game = game;
           //obstacleSprite.UpdateHitbox();
        }

    }
}