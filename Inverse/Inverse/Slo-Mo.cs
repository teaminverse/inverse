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
    class Slo_Mo
    {
        public Sprite sloMoSprite = new Sprite();
        Collisions collision = new Collisions();
        Game1 game = null;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;
            sloMoSprite.Load(content, "sloMo", true);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sloMoSprite.Draw(spriteBatch, game);
            // Random generation off screen moving into view
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            sloMoSprite.Update(deltaTime);
            sloMoSprite.UpdateHitBox();
        }
    }
}
