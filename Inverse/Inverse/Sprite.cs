﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Inverse
{
    public class Sprite
    {
        public Vector2 position = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 offset = Vector2.Zero;

        public bool canJump = false;
        public bool canTeleport = false;
        public bool gravDown = true;

        Texture2D texture;

        public int width = 0;
        public int height = 0;

        //edges are hitbox
        public int leftEdge = 0;
        public int rightEdge = 0;
        public int topEdge = 0;
        public int bottomEdge = 0;

        public int leftCollisionOffset = 0;
        public int rightCollisionOffset = 0;
        public int vertCollisionOffset = 0;

        public bool isBackground = false; 

        List<AnimatedTexture> animations = new List<AnimatedTexture>();
        List<Vector2> animationOffsets = new List<Vector2>();
        int currentAnimation = 0;
        SpriteEffects effects = SpriteEffects.None;

        public float xSpeed = 0f;
        public float ySpeed = 0f;

        public Color spriteColor = Color.White;

        public Sprite()
        {

        }

        public void Load(ContentManager content, string asset, bool useOffset, bool isSpriteSheet = false, int spritesInSheet = 0)
        {
            texture = content.Load<Texture2D>(asset);
            width = texture.Bounds.Width;
            height = texture.Bounds.Height;

            if (useOffset == true)
            {
                offset = new Vector2(leftEdge + width / 2, topEdge + height / 2);
            }

            if (isSpriteSheet)
            {
                width = texture.Bounds.Width / spritesInSheet; 
            }

            UpdateHitBox();
        }
        public void UpdateHitBox()
        {
            leftEdge = (int)position.X - (int)offset.X;
            rightEdge = leftEdge + width;
            topEdge = (int)position.Y - (int)offset.Y;
            bottomEdge = topEdge + height;
        }

        public void Update(float deltaTime)
        {
            animations[currentAnimation].UpdateFrame(deltaTime);
        }

        public void Draw(SpriteBatch spriteBatch, MainGame game)
        {     
            if (game.animatedSprite == true)
            {
                animations[currentAnimation].DrawFrame(spriteBatch, position + animationOffsets[currentAnimation], effects);
            }
            else if (game.animatedSprite == false)
            {
                spriteBatch.Draw(texture, position, Color.White); 
            }
            
            if (game.debug == true && isBackground == false)
            {
                game.DrawRectangle(new Rectangle(leftEdge, topEdge, width - rightCollisionOffset, height - vertCollisionOffset), Color.Red);
            }
        }

        public void AddAnimation(AnimatedTexture animation, int xOffset = 0, int yOffset = 0)
        {
            animations.Add(animation);
            animationOffsets.Add(new Vector2(xOffset, yOffset));
        }

        public void SetFlipped(bool state)
        {
            if (state == true)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effects = SpriteEffects.None;
            }
        }
        public void SetVertFlipped(bool state)
        {
           if (state == true)
            {
                effects = SpriteEffects.FlipVertically;
           }
            else
            {
               effects = SpriteEffects.None;
           }
        }
        public void Pause()

        {
            animations[currentAnimation].Pause();
        }
        public void Play()

        {
            animations[currentAnimation].Play();
        }


    }

}
