﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Inverse
{
    class One_Hit_Shield
    {
        public Sprite oneHitShieldSprite = new Sprite();
        Collisions collision = new Collisions();
        Game1 game = null;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;
            oneHitShieldSprite.Load(content, "oneHitShield", true);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            oneHitShieldSprite.Draw(spriteBatch, game);
            // Random generation off screen moving into view
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            oneHitShieldSprite.Update(deltaTime);
            oneHitShieldSprite.UpdateHitBox();
        }
    }
}
