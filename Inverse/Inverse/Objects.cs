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
    public class Objects
    {
        MainGame game = null;

        public Obstacle obstacle = new Obstacle();

        Random random = new Random();

        int obType = 0;

        int nextPosX = 0;
        int nextPosY = 0;


        public void Load(ContentManager content, MainGame theGame)
        {
            game = theGame; 
            int obType = random.Next(1, 4);

            switch (obType)
            {
                case 1:
                    // Small Obstacle
                    obstacle.myTexture = "obstacle";
                    obstacle.xSpeed = -64;

                    // Randomize the starting poistion 
                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    obstacle.obstacleSprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;
                case 2:
                    // Medium Obstacle
                    //obstacle.myTexture = "";
                    obstacle.xSpeed = -64;

                    // Randomize the starting poistion 
                    nextPosX = random.Next(0, game.GraphicsDevice.Viewport.Width);
                    obstacle.obstacleSprite.position = new Vector2(nextPosX, game.GraphicsDevice.Viewport.Height);
                    break;
                case 3:
                    // Large Obstacle
                    //obstacle.myTexture = "";
                    obstacle.xSpeed = -64;

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

            switch (obType)
            {

                case 1:
                    // Small Obstacle 
                    if (obstacle.obstacleSprite.position.X < 0)
                    {
                        game.obstacleSpawner.spawnedObstacles.Remove(this);
                    }
                        break;
                case 2:

                    break;
                case 3:

                    break;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            obstacle.Draw(spriteBatch);
        }

    }
}