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
        Sprite CollideAbove(Game1 game, Sprite platform, Sprite playerPrediction)
        {
            Sprite ground = platform;

           

            if (IsColliding(playerPrediction, ground) == true && hero.velocity.Y < 0)
            {
                hero.position.Y = ground.bottomEdge + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canjump = true;
            }

            return hero;
        }
        //for right way up ground collision
        Sprite CollideBelow(Game1 game, Sprite platform, Sprite playerPrediction)
        {
            Sprite ground = platform;


        if (IsColliding(playerPrediction, ground) == true && hero.velocity.Y > 0)
            {
                hero.position.Y = ground.topEdge + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canjump = true;
            }

            return hero;
        }
    }
}

                
          
        

    
