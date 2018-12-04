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

        public Obstacle obstacle = new Obstacle();
        public Portal portal = new Portal();

        Random random = new Random();

        public int itemType = 0;

        int nextPosX = 0;
        int nextPosY = 0;


        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame; 
            int itemType = random.Next(1, 2);

            switch (itemType)
            {
                case 1:
                    // Small Obstacle
                    game.myTexture = "obstacle";
                    game.xSpeed = -game.gameSpeed;

                    // Randomize the starting poistion 
                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    obstacle.obstacleSprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;
                case 2:
                    // Portal
                    game.myTexture = "Portal";
                    game.xSpeed = -64;

                    // Randomize the starting poistion 
                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    obstacle.obstacleSprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;
                case 3:
                    // Large Obstacle
                    //obstacle.myTexture = "";
                    game.xSpeed = -64;

                    // Randomize the starting poistion 
                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    obstacle.obstacleSprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;

            }

            obstacle.Load(content, game);
        }

        public void Update(float deltaTime)
        {
            obstacle.Update(deltaTime);

            switch (itemType)
            {

                case 1:
                    // Small Obstacle 
                    if (obstacle.obstacleSprite.position.X < 0)
                    {
                        game.itemSpawner.spawnedItems.Remove(this);
                    }
                        break;
                case 2:
                    // Portal
                    if (portal.portalSprite.position.X < 0)
                    {
                        game.itemSpawner.spawnedItems.Remove(this);
                    }

                    break;
                case 3:

                    break;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            obstacle.Draw(spriteBatch);
            portal.Draw(spriteBatch);
        }

    }
}