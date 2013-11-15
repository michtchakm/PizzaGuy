using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PizzaGuy
{
    enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    
    class PizzaGuy : Sprite
    {
        public Direction direction;

        public PizzaGuy(
            Vector2 location,
            Texture2D texture,
            Rectangle initialFrame,
            Vector2 velocity):
                base(location, texture, initialFrame, velocity)
        {       
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
            
        public override void  Draw(SpriteBatch spriteBatch)
        {
 	         base.Draw(spriteBatch);
        }

    }
}
