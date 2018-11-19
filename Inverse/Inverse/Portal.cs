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
    public class Portal
    {
        public Sprite portalSprite = new Sprite();
        Collisions collision = new Collisions();
        Game1 game = null;

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;
            portalSprite.Load(content, "Portal #1", true);

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            portalSprite.Draw(spriteBatch, game);
            // Random generation off screen moving into view
        }

        public void Update(float deltaTime)
        {
            collision.game = game;
            portalSprite.Update(deltaTime);
            portalSprite.UpdateHitBox();
        }
    }
}
