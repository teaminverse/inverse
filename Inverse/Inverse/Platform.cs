using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Inverse
{
    public class Platform
    {
        public Sprite platformSprite = new Sprite();
        //Collision collision = new Collision();
        Game1 game = null;
        public Vector2 platform = new Vector2(0, 0);

        public void Load(ContentManager content, Game1 theGame)
        {
            game = theGame;

            platformSprite.Load(content, "Platform (test)", true );         
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            platformSprite.Draw(spriteBatch, game);
        }

        public void Update(float deltaTime)
        {
            //collision.game = game;
            platformSprite.Update(deltaTime);
            platformSprite.UpdateHitBox();
        }
    }
}
