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

        public Obstacle obstacle = new Obstacle();
        public Portal portal = new Portal();

        public bool removeItem = false;

        float screenBuffer = -300f;          // remove items  after they move this amount of pixels off screen

        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame; 
            itemType = random.Next(1, 3);

            switch (itemType)
            {
                case 1:
                    // Small Obstacle
                    obstacle.textureToLoad = "obstacle";
                    obstacle.obstacleSprite.xSpeed = -game.gameSpeed;

                    // Init obstacle
                    obstacle.Load(content, game);

                    // Randomize between top and bottom (to be implemented)
                    obstacle.obstacleSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, (game.GraphicsDevice.Viewport.Height / 2) - (game.platform.platformSprite.height / 2));
                    break;
                case 2:
                    // Portal
                    portal.textureToLoad = "Portal";
                    portal.portalSprite.xSpeed = -game.gameSpeed;

                    // Init portal
                    portal.Load(content, game);

                    // set portal position
                    portal.portalSprite.position = new Vector2(game.GraphicsDevice.Viewport.Width, (game.GraphicsDevice.Viewport.Height / 2) - (game.platform.platformSprite.height / 2));
                    break;
                case 3:
                    // Large Obstacle
                    //largeObstacle.myTexture = "LargeObstacle";
                    //largeObstacle.largeObstacleSprite.xSpeed = -game.gameSpeed;

                    // Randomize the starting poistion 
                    //nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    //largeObstacle.obstacleSprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;
            }          
        }

        public void Update(float deltaTime)
        {
            switch (itemType)
            {
                case 1:
                    // Small Obstacle 
                    obstacle.Update(deltaTime);
                    if (obstacle.obstacleSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 2:
                    // Portal
                    portal.Update(deltaTime);
                    if (portal.portalSprite.position.X < screenBuffer)
                    {
                        removeItem = true;
                        game.itemSpawner.spawnedItems.Remove(this);
                        return;
                    }
                    break;
                case 3:

                    break;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (itemType)
            {
                case 1:
                    // Small Obstacle 
                    obstacle.Draw(spriteBatch);
                    break;
                case 2:
                    // Portal
                    portal.Draw(spriteBatch);
                    break;
                case 3:

                    break;
            }
        }
    }
}