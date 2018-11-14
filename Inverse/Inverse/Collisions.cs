using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Inverse
{
    class Collisions
    {
        public bool IsColliding(Sprite hero, Sprite otherSprite)
        {
            // compare postions of each rectangle edge ie left edge to right edge
            if (hero.rightEdge < otherSprite.leftEdge ||
                hero.leftEdge > otherSprite.rightEdge ||
                hero.bottomEdge < otherSprite.topEdge ||
                hero.topEdge > otherSprite.bottomEdge)
            {
                return false;
            }


            return true;
        }


        //need to find platform edges??? 


        // for upsidedown ground collision
        Sprite CollideAbove(Sprite hero, Sprite platform)
        {
            
            if (IsColliding(hero, platform) == true && hero.velocity.Y < 0)
            {
                hero.position.Y = platform.bottomEdge + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canjump = true;
            }

            return hero;
        }
        //for right way up ground collision
        Sprite CollideBelow(Sprite hero, Sprite platform)
        {
            Sprite ground = platform;

<<<<<<< HEAD
            if (IsColliding(playerPrediction, ground) == true && platform.velocity.Y > 0)
=======
            if (IsColliding(hero,platform ) == true && hero.velocity.Y > 0)
>>>>>>> 65a663f6f1840fa9d4fb66d8fe323d4e65d4ab40
            {
                platform.position.Y = ground.topEdge - platform.height + platform.offset.Y;
                platform.velocity.Y = 0;
                platform.canjump = true;
            }

            return platform;
        }
    }
}

                
          
        

    
