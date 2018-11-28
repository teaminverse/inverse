using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Inverse
{
    public class Collisions
    {
        public MainGame game { get; internal set; }

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
        public Sprite CollideAbove(Sprite hero, Sprite platform, float deltaTime)
        {

            if (IsColliding(hero, platform) == true && hero.velocity.Y < 0)
            {
                hero.position.Y = platform.bottomEdge + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canJump = true;
            }

            return hero;
        }
        //for right way up ground collision
        public Sprite CollideBelow(Sprite hero, Sprite platform, float deltaTime)
        {
            if (IsColliding(hero, platform) == true && hero.velocity.Y > 0)

            {

                hero.position.Y = platform.topEdge - hero.height + hero.offset.Y;
                hero.velocity.Y = 0;
                hero.canJump = true;


            }

            return hero;
        }
        //for upsidedown portal collision
        public Sprite CollideAbovePortal(Sprite hero, Sprite portal, float deltaTime)
        {

            if (IsColliding(hero, portal) == true && hero.velocity.Y < 0)
            {
                hero.position.Y = portal.topEdge + hero.offset.Y;
                hero.gravDown = false; 

                //hero.velocity.Y = 0;
                hero.canJump = true;
            }

            return hero;
        }
        //for right way up portal collision
        public Sprite CollideBelowPortal(Sprite hero, Sprite portal, float deltaTime)
        {
            if (IsColliding(hero, portal) == true)

            {

                hero.position.Y = portal.bottomEdge + hero.height + hero.offset.Y;
                //hero.gravityDown = false;

                //hero.velocity.Y = 0;
                hero.canJump = true;


            }

            return hero;

        }

        //public Sprite CollideObstacle(Sprite hero, Sprite obstacle, float deltaTime)
        //{
        //    if (IsColliding(hero, obstacle) == true && hero.velocity.Y > 0)
        //    {
        //        hero.position.Y = obstacle.rightEdge - hero.height + hero.offset.Y;
        //        hero.position.Y = obstacle.bottomEdge - hero.height + hero.offset.Y;
        //    }

      //  }
    }
}






