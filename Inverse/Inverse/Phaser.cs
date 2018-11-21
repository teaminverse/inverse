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

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;
            phaserSprite.Load(content, "phaser", true);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            phaserSprite.Draw(spriteBatch, game);
            // Random generation off screen moving into view
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            phaserSprite.Update(deltaTime);
            phaserSprite.UpdateHitBox();
        }
    }
}
