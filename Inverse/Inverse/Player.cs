using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Inverse
{
    public class Player
    {
        public Sprite playerSprite = new Sprite();
        public Sprite playerJump = new Sprite();
        public bool gravDown = true;
        MainGame game = null;
        public float jumpStrength = 25000f;


        Collisions collision = new Collisions();

        public Player()
        {

        }
        public void Load(ContentManager content, MainGame theGame)
        {
            playerSprite.Load(content, "Ninja", true);
            game = theGame;

            AnimatedTexture runAnimation = new AnimatedTexture(playerSprite.offset, 0, 1, 1);
            runAnimation.Load(content, "Run", 10, game.playerFPS);
            playerSprite.AddAnimation(runAnimation, 0, -5);
            playerSprite.Play();

            playerSprite.velocity = Vector2.Zero;
            playerSprite.position = new Vector2(50, 150);
        }

        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
            playerSprite.UpdateHitBox();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch, game);
        }

        private void UpdateInput(float deltaTime)
        {
            if (playerSprite.canJump == true)
            {
                playerSprite.Play();
            }
            else
            {
                playerSprite.Pause();          
            }

            foreach (Item item in game.itemSpawner.spawnedItems)
            {
                if (collision.IsColliding(playerSprite, item.smallObstacle.smallObSprite) 
                    || collision.IsColliding(playerSprite, item.mediumObstacle.mediumObSprite) 
                    || collision.IsColliding(playerSprite, item.largeObstacle.largeObSprite)
                    || collision.IsColliding(playerSprite, item.portal.portalSprite) 
                    || collision.IsColliding(playerSprite, item.phaser.phaserSprite)
                    || collision.IsColliding(playerSprite, item.plusScore.plusScoreSprite)
                    || collision.IsColliding(playerSprite, item.oneHitShield.oneHitShieldSprite)
                    || collision.IsColliding(playerSprite, item.sloMo.sloMoSprite) 
                    || collision.IsColliding(playerSprite, item.portaPortal.portaPortalSprite) == true)
                {
                    switch (item.itemType)
                    {
                        case 1:
                            // SmallOb
                            game.Exit();
                            break;
                        case 2:
                            // MedOb
                            game.Exit();
                            break;
                        case 3:
                            // LargeOb
                            game.Exit();
                            break;
                        case 4:
                            // Portal
                                game.gravity = new Vector2(0, -1000);
                                playerSprite.position = new Vector2(100, 400);
                            game.upsideDown = true;
                            playerSprite.SetVertFlipped(true);   
                            break;
                        case 5:
                            // Phaser
                            game.phaserPickUp = true;
                            if(collision.IsColliding(playerSprite, item.largeObstacle.largeObSprite) 
                                || collision.IsColliding(playerSprite, item.mediumObstacle.mediumObSprite) 
                                || collision.IsColliding(playerSprite, item.smallObstacle.smallObSprite) == true)
                            {
                                return; 
                            }
                            break;
                        case 6:
                            // PlusScore
                            game.totalScore += 50; 
                            break;
                        case 7:
                            // OneHitShield
                            break;
                        case 8:
                            // SloMo
                                game.gameSpeed = 10000;
                            game.playerFPS = 10; 
                            break;
                        case 9:
                            // PortaPortal
                            game.portaPortalOn = true;
                            if (Keyboard.GetState().IsKeyDown(Keys.Down) == true && game.portaPortalOn == true)
                            {
                                game.gravity = new Vector2(0, -1000);
                                game.upsideDown = true;
                                playerSprite.SetVertFlipped(true);
                            }
                            break;
                    }                      
                }
            }

            if (collision.IsColliding(playerSprite, game.platform.platformSprite) == true)
            {
                playerSprite.position.Y = game.platform.platformSprite.topEdge - playerSprite.height + playerSprite.offset.Y;

                playerSprite.velocity.Y = 0;
                playerSprite.canJump = true;
            }

            if (playerSprite.gravDown == true)
            {
                Vector2 localAcceleration = game.gravity;

               /* if (playerSprite.canTeleport == true)
                {
                    playerSprite = collision.CollideBelowPortal(playerSprite, game.portal.portalSprite, deltaTime);
                }*/

                playerSprite = collision.CollideBelow(playerSprite, game.platform.platformSprite, deltaTime);

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && playerSprite.canJump == true 
                    || Keyboard.GetState().IsKeyDown(Keys.W) && playerSprite.canJump == true 
                    || Keyboard.GetState().IsKeyDown(Keys.Up) && playerSprite.canJump == true)
                {
                    playerSprite.canJump = false;
                    localAcceleration.Y -= jumpStrength;
                }

                playerSprite.velocity += localAcceleration * deltaTime;
                playerSprite.position += playerSprite.velocity * deltaTime;
            }
            else
            {
               // playerSprite = collision.CollideAbovePortal(playerSprite, game.portal.portalSprite, deltaTime);
                playerSprite = collision.CollideAbove(playerSprite, game.platform.platformSprite, deltaTime);
            

                Vector2 localAcceleration = -game.gravity;

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && playerSprite.canJump == true)

                {
                    playerSprite.canJump = false;
                    localAcceleration.Y += jumpStrength;

                }

                playerSprite.velocity += localAcceleration * deltaTime;
                playerSprite.position += playerSprite.velocity * deltaTime;
            }

        }   
    }
}