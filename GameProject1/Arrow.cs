using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject1
{
    /// <summary>
    /// class to represent an arrow sprite
    /// </summary>
    public class Arrow
    {
        private Texture2D arrow;

        public Direction direction;
        public Vector2 Position;

        /// <summary>
        /// loads the knight texture
        /// </summary>
        /// <param name="content">the ContentManager to load with</param>
        public Arrow(Texture2D content)
        {
            arrow = content;
        }

        /// <summary>
        /// updates the sprite's position based on user input
        /// </summary>
        /// <param name="gameTime">the game time</param>
        public void Update(GameTime gameTime)
        {
            switch (direction)
            {
                case Direction.Up:
                    Position += new Vector2(0, -1) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Down:
                    Position += new Vector2(0, 1) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        /// <summary>
        /// draws the arrow sprite
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="spriteBatch">the SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            var source = new Rectangle(768, 192, 64, 64);
            switch (direction)
            {
                case Direction.Up:
                    spriteBatch.Draw(arrow, Position, source, Color.White, (float)Math.PI / 2, new Vector2(632, 32), new Vector2(1, 1),SpriteEffects.None, 0);
                    break;
                case Direction.Down:
                    spriteBatch.Draw(arrow, Position, source, Color.White, (float)Math.PI * 3 / 2, new Vector2(32, 32), new Vector2(1, 1),SpriteEffects.None, 0);
                    break;
                case Direction.Left:
                    spriteBatch.Draw(arrow, Position, source, Color.White, (float)Math.PI, new Vector2(32, 32), new Vector2(1, 1), SpriteEffects.None, 0);
                    break;
                case Direction.Right:
                    spriteBatch.Draw(arrow, Position, source, Color.White);
                    break;
            }
        }
    }
}
