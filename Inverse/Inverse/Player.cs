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
using Microsoft.Xna.Framework.Media;


namespace Inverse
{
    public class Player
    {
        public Sprite playerSprite = new Sprite();
        public Sprite playerJump = new Sprite();

        MainGame game = null;
        public float jumpStrength = 25000;

        public bool isPhasing = false;
        public float phaseTime = 6f;
        public float phaseTimer = 0f;

        bool isShielded = false;

        public bool sloMotion = false;
        public float sloMoTime = 6f;
        public float sloMoTimer = 0f;

        bool canPort = true;
        float portalTime = 1f;
        float portalTimer = 0f;

        bool removeArrayObject = false;

      //  SoundEffect plusScoreSound;
      //  SoundEffectInstance plusScoreSoundInstance; 

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

            //plusScoreSound = content.Load<SoundEffect>("itemPickup.mp3");
          //  plusScoreSoundInstance = plusScoreSound.CreateInstance();

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
                game.phaserPickUp = false; 
            }

            portalTimer -= deltaTime;

            if (portalTimer < 0)
            {
                canPort = true;
            }

            sloMoTimer -= deltaTime;

            if (sloMoTimer < 0)
            {
                sloMotion = false;
                game.gameSpeed = 20000;
                jumpStrength = 35000;
                game.sloMoPickUp = false; 
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
            if (isPhasing == false && isShielded == false)
            {
                if (collision.IsColliding(playerSprite, item.smallObstacle.smallObSprite)
                || collision.IsColliding(playerSprite, item.mediumObstacle.mediumObSprite)                
                == true)
                {
                    switch (item.itemType)
                    {
                        case 1:
                            // SmallOb
                            game.gameState += 1;
                            break;
                        case 2:
                            // MedOb
                            game.gameState += 1;
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
                    case 3:
                        // Portal
                        game.upsideDown = true; 
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
            || collision.IsColliding(playerSprite, item.sloMo.sloMoSprite)
            == true)
            {
                switch (item.itemType)
                {
                    case 4:
                        // Phaser
                        if (isPhasing == false)
                        {
                            isPhasing = true;
                            phaseTimer = phaseTime; // reset the timer
                            game.phaserPickUp = true;
                            game.powerUp = false; 
                        }

                        removeArrayObject = true;

                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                    case 5:
                        // PlusScore
                        game.totalScore += 50;
                        removeArrayObject = true;
                        //plusScoreSoundInstance.Play();
                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                    case 6:
                        // SloMo       
                        if (sloMotion == false)
                        {
                            sloMotion = true;                       
                            game.gameSpeed = 10000;
                            game.sloMoPickUp = true; 
                            sloMoTimer = sloMoTime; // reset the timer 
                        } 
                    
                        removeArrayObject = true;

                        game.itemSpawner.spawnedItems.Remove(item); // remove item from array

                        break;
                }
            }
        }
    }
}