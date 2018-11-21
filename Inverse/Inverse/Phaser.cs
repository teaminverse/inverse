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
    class Phaser
    {
        public Sprite phaserSprite = new Sprite();
        Collisions collision = new Collisions();
        Game1 game = null;
        float phaserSpeed = 0;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "phaser", 1, 1);

            phaserSprite.AddAnimation(animation, 0, 3);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            phaserSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            phaserSprite.velocity = new Vector2(phaserSpeed, 0) * deltaTime;
            phaserSprite.position += phaserSprite.velocity * deltaTime;


            //obstacleSprite.UpdateHitbox();

        }
    }
}
