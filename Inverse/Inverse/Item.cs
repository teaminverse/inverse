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
    public class Item
    {
        MainGame game = null;

        Random random = new Random();

        public int itemType = 0;

        public SmallObstacle smallObstacle = new SmallObstacle();
        public MediumObstacle mediumObstacle = new MediumObstacle();
        public LargeObstacle largeObstacle = new LargeObstacle();
        public PortaPortal portaPortal = new PortaPortal();
        public Phaser phaser = new Phaser();
        public OneHitShield oneHitShield = new OneHitShield();
        public PlusScore plusScore = new PlusScore();
        public Slo_Mo sloMo = new Slo_Mo();
        public Portal portal = new Portal();

        public int spawnPos = 0; 

        public bool removeItem = false;

        float screenBuffer = -300f;          // remove items  after they move this amount of pixels off screen

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame; 
            itemType = random.Next(1, 5);

            switch (itemType)
            {
                case 1:
                    // Small Obstacle
                    if (game.upsideDown == false)
                    {
                        spawnPos = 190;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 250;
                    }
                    smallObstacle.textureToLoad = "obstacle";
                    smallObstacle.smallObSprite.xSpeed = -game.gameSpeed;

                    // Init smallObstacle
                    smallObstacle.Load(content, game);

                    // Randomize between top and bottom (to be implemented)
                    smallObstacle.smallObSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 2:
                    // Medium Obstacle
                    if (game.upsideDown == false)
                    {
                        spawnPos = 190;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 250;
                    }

                    mediumObstacle.textureToLoad = "Medium Ob";
                    mediumObstacle.mediumObSprite.xSpeed = -game.gameSpeed;

                    // Init mediumObstacle
                    mediumObstacle.Load(content, game);

                    mediumObstacle.mediumObSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 3:
                    // Large Obstacle 
                    if (game.upsideDown == false)
                    {
                        spawnPos = 190;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 250;
                    }
                    largeObstacle.textureToLoad = "Large Ob";
                    largeObstacle.largeObSprite.xSpeed = -game.gameSpeed;

                    // Init largeObstacle
                    largeObstacle.Load(content, game);

                    largeObstacle.largeObSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 4:
                    // Portal
                    portal.textureToLoad = "Portal";
                    portal.portalSprite.xSpeed = -game.gameSpeed;

                    // Init portal
                    portal.Load(content, game);

                    // set portal position
                    portal.portalSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, 162);
                    break;
                case 5:
                    // Phaser
                    if (game.upsideDown == false)
                    {
                        spawnPos = 140;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 300;
                    }
                    phaser.textureToLoad = "phaser";
                    phaser.phaserSprite.xSpeed = -game.gameSpeed;

                    // Init Phaser
                    phaser.Load(content, game);

                    // set Phaser position
                    phaser.phaserSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 6:
                    // PlusScore
                    if (game.upsideDown == false)
                    {
                        spawnPos = 140;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 300;
                    }
                    plusScore.textureToLoad = "extraLife";
                    plusScore.plusScoreSprite.xSpeed = -game.gameSpeed;

                    // Init PlusScore
                    plusScore.Load(content, game);

                    // set PlusScore position
                    plusScore.plusScoreSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 7:
                    // OneHitShield
                    if (game.upsideDown == false)
                    {
                        spawnPos = 140;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 300;
                    }
                    oneHitShield.textureToLoad = "oneHitShield";
                    oneHitShield.oneHitShieldSprite.xSpeed = -game.gameSpeed;

                    // Init OneHitShield
                    oneHitShield.Load(content, game);

                    // set OneHitShield position
                    oneHitShield.oneHitShieldSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 8:
                    // SloMo
                    if (game.upsideDown == false)
                    {
                        spawnPos = 140;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 300;
                    }
                    sloMo.textureToLoad = "sloMo";
                    sloMo.sloMoSprite.xSpeed = -game.gameSpeed;

                    // Init SloMo
                    sloMo.Load(content, game);

                    // set SloMo position
                    sloMo.sloMoSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
                case 9:
                    // PortaPortal
                    if (game.upsideDown == false)
                    {
                        spawnPos = 140;
                    }
                    else if (game.upsideDown == true)
                    {
                        spawnPos = 300;
                    }
                    portaPortal.textureToLoad = "portaPortal";
                    portaPortal.portaPortalSprite.xSpeed = -game.gameSpeed;

                    // Init PortaPortal
                    portaPortal.Load(content, game);

                    // set PortaPortal position
                    portaPortal.portaPortalSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, spawnPos);
                    break;
            }
        }

        public void Update(float deltaTime)
        {
            switch (itemType)
            {
                case 1:
                    // Small Obstacle 
                    smallObstacle.Update(deltaTime);
                    if (smallObstacle.smallObSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 2:
                    // Medium Obstacle
                    mediumObstacle.Update(deltaTime);
                    if (mediumObstacle.mediumObSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 3:
                    // Large Obstacle 
                    largeObstacle.Update(deltaTime);
                    if (largeObstacle.largeObSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 4:
                    // Portal
                    portal.Update(deltaTime);
                    if (portal.portalSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 5:
                    // Phaser
                    phaser.Update(deltaTime);
                    if (phaser.phaserSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 6:
                    // PlusScore
                    plusScore.Update(deltaTime);
                    if (plusScore.plusScoreSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 7:
                    // OneHitShield
                    oneHitShield.Update(deltaTime);
                    if (oneHitShield.oneHitShieldSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 8:
                    // SloMo
                    sloMo.Update(deltaTime);
                    if (sloMo.sloMoSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 9:
                    // PortaPortal
                    portaPortal.Update(deltaTime);
                    if (portaPortal.portaPortalSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (itemType)
            {
                case 1:
                    // Small Obstacle 
                    smallObstacle.Draw(spriteBatch);
                    break;
                case 2:
                    // Medium Obstacle
                    mediumObstacle.Draw(spriteBatch);
                    break;
                case 3:
                    // Large Obstacle 
                    largeObstacle.Draw(spriteBatch);
                    break; 
                case 4:
                    // Portal
                    portal.Draw(spriteBatch);
                    break;
                case 5:
                    // Phaser
                    phaser.Draw(spriteBatch);
                    break;
                case 6:
                    // PlusScore
                    plusScore.Draw(spriteBatch);
                    break;
                case 7:
                    // OneHitShield
                    oneHitShield.Draw(spriteBatch);
                    break;
                case 8:
                    // SloMo
                    sloMo.Draw(spriteBatch);
                    break;
                case 9:
                    // PortaPortal
                    portaPortal.Draw(spriteBatch);
                    break;
            }
        }
    }
}