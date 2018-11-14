using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Inverse
{
<<<<<<< HEAD
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

        Sprite CollideAbove(Game1 game, Sprite hero, Vector2 GroundPos, Sprite playerPrediction)
        {
            Sprite ground = ;
            if (IsColliding(playerPrediction, ground) == true && hero.velocity.Y < 0)
            {
                hero.position.Y = ground.topEdge + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canjump = true;
            }

            return hero;
        }

        Sprite CollideBelow(Game1 game, Sprite hero, Vector2 GroundPos, Sprite playerPrediction)
        {
            Sprite ground = ;


        if (IsColliding(playerPrediction, ground) == true && hero.velocity.Y > 0)
            {
                hero.position.Y = ground.bottomEdge + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canjump = true;
            }

            return hero;
        }
    }
}

                
          
        

    
=======
    class Collision
    {

    }
}
>>>>>>> 7317f9d48e379f9fc1cce2deb53fbdc308a395d3
