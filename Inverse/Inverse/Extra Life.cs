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
    class Extra_Life
    {
        public Sprite extraLifeSprite = new Sprite();
        Collisions collision = new Collisions();
        Game1 game = null;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;
            extraLifeSprite.Load(content, "extraLife", true);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            extraLifeSprite.Draw(spriteBatch, game);
            // Random generation off screen moving into view
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            extraLifeSprite.Update(deltaTime);
            extraLifeSprite.UpdateHitBox();
        }
    }
}
