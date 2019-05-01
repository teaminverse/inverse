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
    public class Phaser
    {
        MainGame game = null;

        public Sprite phaserSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;

            phaserSprite.Load(content, textureToLoad, false, true, 1);

            AnimatedTexture phaserAnimation = new AnimatedTexture(phaserSprite.offset, 0, 1, 1);

            phaserAnimation.Load(content, textureToLoad, 1, 1);
            phaserSprite.AddAnimation(phaserAnimation, 0, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            phaserSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            phaserSprite.velocity = new Vector2(phaserSprite.xSpeed, 0) * deltaTime;

            phaserSprite.position += phaserSprite.velocity * deltaTime;

            phaserSprite.Update(deltaTime);
            phaserSprite.UpdateHitBox();
        }

    }
}
