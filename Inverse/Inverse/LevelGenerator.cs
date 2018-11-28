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
    public class LevelGenerator
    {
        MainGame game = null;
        ArrayList spawnableThings = new ArrayList();
        Random rand = new Random();

        ContentManager content = null;

        float objectSpawnTime;
        float objectDefaultSpawnTime = 1.0f;

        int nextThing = 0;


        public void Load(ContentManager theContent, MainGame theGame)
        {
            game = theGame;
            content = theContent;

            spawnableThings.Add(new Obstacle());
            spawnableThings.Add(new Extra_Life());
            spawnableThings.Add(new Portal());
            spawnableThings.Add(new One_Hit_Shield());
            spawnableThings.Add(new Phaser());
            spawnableThings.Add(new Slo_Mo());
            objectSpawnTime = objectDefaultSpawnTime;

            nextThing = rand.Next(1, spawnableThings.Count);
        }

        public void Update(float deltaTime)
        {
            // Decreasing our objectspawntimer
           /* objectSpawnTime -= deltaTime;

            // If timer is expired
            if (objectSpawnTime <= 0)
            {
                // Spawn an object
                game.spawnedObjects.Add(spawnableThings[nextThing]);

                // Activate load function
                if (game.spawnedObjects[game.spawnedObjects.Count] is Obstacle)
                {
                    Obstacle thisObstacle = (Obstacle)game.spawnedObjects[game.spawnedObjects.Count];
                    thisObstacle.Load(content, game);
                }

                else if (game.spawnedObjects[game.spawnedObjects.Count] is Portal)
                {
                    Portal thisPortal = (Portal)game.spawnedObjects[game.spawnedObjects.Count];
                    thisPortal.Load(content, game);
                }

                // Reset the timer 
                objectSpawnTime = objectDefaultSpawnTime; 

                // Randomize again for next spawn
                nextThing = rand.Next(1, spawnableThings.Count);
            }*/
        }
    }
}
