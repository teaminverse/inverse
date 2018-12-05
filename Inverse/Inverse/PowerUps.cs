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
    public class PowerUps
    {
        MainGame game = null;
        public Sprite phaserSprite = new Sprite();
        public Sprite oneHitShieldSprite = new Sprite();
        public Sprite plusScoreSprite = new Sprite();
        public Sprite sloMoSprite = new Sprite();
        public Sprite portaPortalSprite = new Sprite();
        Collisions collision = new Collisions();

        public string textureToLoad = null; 

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame;
            AnimatedTexture phaserAnimation = new AnimatedTexture(phaserSprite.offset, 0, 1, 1);
            AnimatedTexture oneHitShieldAnimation = new AnimatedTexture(oneHitShieldSprite.offset, 0, 1, 1);
            AnimatedTexture plusScoreAnimation = new AnimatedTexture(plusScoreSprite.offset, 0, 1, 1);
            AnimatedTexture sloMoAnimation = new AnimatedTexture(sloMoSprite.offset, 0, 1, 1);
            AnimatedTexture portaPortalAnimation = new AnimatedTexture(portaPortalSprite.offset, 0, 1, 1);

            phaserAnimation.Load(content, textureToLoad, 1, 1);
            phaserSprite.AddAnimation(phaserAnimation, 0, 0);

            oneHitShieldAnimation.Load(content, textureToLoad, 1, 1);
            phaserSprite.AddAnimation(oneHitShieldAnimation, 0, 0);

            plusScoreAnimation.Load(content, textureToLoad, 1, 1);
            plusScoreSprite.AddAnimation(plusScoreAnimation, 0, 0);

            sloMoAnimation.Load(content, textureToLoad, 1, 1);
            sloMoSprite.AddAnimation(sloMoAnimation, 0, 0);

            portaPortalAnimation.Load(content, textureToLoad, 1, 1);
            portaPortalSprite.AddAnimation(portaPortalAnimation, 0, 0);
        }

        public void Update(float deltaTime)
        {
            collision.game = game;

            phaserSprite.velocity = new Vector2(phaserSprite.xSpeed, 0) * deltaTime;
            oneHitShieldSprite.velocity = new Vector2(oneHitShieldSprite.xSpeed, 0) * deltaTime;
            plusScoreSprite.velocity = new Vector2(plusScoreSprite.xSpeed, 0) * deltaTime;
            sloMoSprite.velocity = new Vector2(sloMoSprite.xSpeed, 0) * deltaTime;
            portaPortalSprite.velocity = new Vector2(portaPortalSprite.xSpeed, 0) * deltaTime;

            phaserSprite.position += phaserSprite.velocity * deltaTime;
            oneHitShieldSprite.position += oneHitShieldSprite.velocity * deltaTime;
            oneHitShieldSprite.position += oneHitShieldSprite.velocity * deltaTime;
            oneHitShieldSprite.position += oneHitShieldSprite.velocity * deltaTime;
            plusScoreSprite.position += plusScoreSprite.velocity * deltaTime;
            sloMoSprite.position += sloMoSprite.velocity * deltaTime;
            portaPortalSprite.position += portaPortalSprite.velocity * deltaTime;

            phaserSprite.Update(deltaTime);
            phaserSprite.UpdateHitBox();          
            oneHitShieldSprite.Update(deltaTime);
            oneHitShieldSprite.UpdateHitBox();       
            plusScoreSprite.Update(deltaTime);
            plusScoreSprite.UpdateHitBox();                    
            sloMoSprite.Update(deltaTime);
            sloMoSprite.UpdateHitBox();                        
            portaPortalSprite.Update(deltaTime);
            portaPortalSprite.UpdateHitBox();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            phaserSprite.Draw(spriteBatch, game);
            oneHitShieldSprite.Draw(spriteBatch, game);
            plusScoreSprite.Draw(spriteBatch, game);
            sloMoSprite.Draw(spriteBatch, game);
            portaPortalSprite.Draw(spriteBatch, game);
        }

    }
}
    

