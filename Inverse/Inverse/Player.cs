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

        MainGame game = null;
        public float jumpStrength = 35000f;

        bool isPhasing = false;
        float phaseTime = 8f;
        float phaseTimer = 0f;

        bool canPort = true;
        float portalTime = 1f;
        float portalTimer = 0f;

        bool removeArrayObject = false;

        

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
            playerSprite.position = new Vector2(100, 150);
        }

        public void Update(float deltaTime)
        {
            CheckTimers(deltaTime);
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
            playerSprite.UpdateHitBox();
        }

        void CheckTimers(float deltaTime)
        {
            phaseTimer -= deltaTime;

            if (phaseTimer < 0)
            {
                isPhasing = false;
            }

            portalTimer -= deltaTime;

            if (portalTimer < 0)
            {
                canPort = true;
            }
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
                CheckCollisionsWithObstacles(item);
                CheckCollisionsWithPortals(item);
                CheckCollisionsWithPowerUps(item);

                if (removeArrayObject == true)
                {
                    removeArrayObject = false;
                    break;
                }
            }

            /*
            if (collision.IsColliding(playerSprite, game.platform.platformSprite) == true)
            {
                playerSprite.position.Y = game.platform.platformSprite.topEdge - playerSprite.height + playerSprite.offset.Y;

                playerSprite.velocity.Y = 0;
                playerSprite.canJump = true;
            }
            */
            

            if (playerSprite.gravDown == true)
            {
                Vector2 localAcceleration = game.gravity;

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
        

        void CheckCollisionsWithObstacles(Item item)
        {
            if (isPhasing == false)
            {
                if (collision.IsColliding(playerSprite, item.smallObstacle.smallObSprite)
                || collision.IsColliding(playerSprite, item.mediumObstacle.mediumObSprite)
                || collision.IsColliding(playerSprite, item.largeObstacle.largeObSprite)
                == true)
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
                    }
                }
            }

        }

        void CheckCollisionsWithPortals(Item item)
        {
            if (collision.IsColliding(playerSprite, item.portal.portalSprite) == true)
            {
                switch (item.itemType)
                {
                    case 4:
                        // Portal

                        // use a timer to prevent player moving back through portal?
                        if (canPort == true)
                        {
                            if (playerSprite.gravDown == true)
                            {
                                playerSprite.gravDown = false;

                                playerSprite.position = new Vector2(playerSprite.position.X, item.portal.portalSprite.bottomEdge);
                                playerSprite.SetVertFlipped(true);
   
                                canPort = false;
                                portalTimer = portalTime;

                            }
                            else if (playerSprite.gravDown == false)
                            {
                                playerSprite.gravDown = true;

                                playerSprite.position = new Vector2(playerSprite.position.X, item.portal.portalSprite.topEdge);
                                playerSprite.SetVertFlipped(false);

                                canPort = false;
                                portalTimer = portalTime;
                            }
                        }
                        break;
                }
            }
        }

        void CheckCollisionsWithPowerUps(Item item)
        {
            if (collision.IsColliding(playerSprite, item.phaser.phaserSprite)
            || collision.IsColliding(playerSprite, item.plusScore.plusScoreSprite)
            || collision.IsColliding(playerSprite, item.oneHitShield.oneHitShieldSprite)
            || collision.IsColliding(playerSprite, item.sloMo.sloMoSprite)
            == true)
            {
                switch (item.itemType)
                {
                    case 5:
                        // Phaser
                        if (isPhasing == false)
                        {
                            isPhasing = true;
                            phaseTimer = phaseTime; // reset the timer
                        }

                        removeArrayObject = true;

                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                    case 6:
                        // PlusScore
                        game.totalScore += 50;

                        removeArrayObject = true;

                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                    case 7:
                        // OneHitShield
                        removeArrayObject = true;

                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                    case 8:
                        // SloMo
                        game.gameSpeed = 10000;
                        game.playerFPS = 10;

                        removeArrayObject = true;

                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                }
            }
        }
    }
}