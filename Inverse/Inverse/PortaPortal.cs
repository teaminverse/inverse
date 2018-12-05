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
    public class PortaPortal
    {
        MainGame game = null;

        public Sprite portaPortalSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null;

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;
            AnimatedTexture portaPortalAnimation = new AnimatedTexture(portaPortalSprite.offset, 0, 1, 1);

            portaPortalAnimation.Load(content, textureToLoad, 1, 1);
            portaPortalSprite.AddAnimation(portaPortalAnimation, 0, 0);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            portaPortalSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            portaPortalSprite.velocity = new Vector2(portaPortalSprite.xSpeed, 0) * deltaTime;

            portaPortalSprite.position += portaPortalSprite.velocity * deltaTime;

            portaPortalSprite.Update(deltaTime);
            portaPortalSprite.UpdateHitBox();
        }


    }
}
    

