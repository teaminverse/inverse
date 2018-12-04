using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections;
using Microsoft.Xna.Framework.Content;

namespace Inverse
{
    public class ItemSpawner
    {
        MainGame game = null;
        ContentManager content = null;

        public float spawnTimer = 0f;
        float defaultSpawnTimer = 2.5f;

        public ArrayList spawnedItems = new ArrayList();

        int currentScoreLevel = 30; // score when difficulty increases
        float spawnTimerChange = 0.2f; // the amount of time to take off the current spawn timer on difficulty increase
        float maxSpawnRate = 0.2f; // the maximum spawn rate

        public void Load(ContentManager theContent, MainGame theGame)
        {
            spawnTimer = defaultSpawnTimer;          
            game = theGame;
            content = theContent; 
        }

        public void Update(float deltaTime)
        {
            // Decreasing our spawntimer
            spawnTimer -= deltaTime;

            // If timer is expired
            if (spawnTimer <= 0)
            {
                // New instance of object
                Item newItem = new Item();

                // Run the Load function of our item
                newItem.Load(content, game);

                // Add this instance to ArrayList
                spawnedItems.Add(newItem);

                /*
                // Increase difficulty
                if (game.totalScore > currentScoreLevel)
                {
                    defaultSpawnTimer -= spawnTimerChange;
                    currentScoreLevel += 30;
                    game.gameSpeed *= game.speedMultiplier;

                    // Prevent spawn rate getting too low
                    if (defaultSpawnTimer < maxSpawnRate)
                    {
                        defaultSpawnTimer = maxSpawnRate;
                    }
                }
                */

                // Reset the timer 
                spawnTimer = defaultSpawnTimer;
            }
        }
    }
}
