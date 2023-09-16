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
    public enum Direction
    {
        Up = 0,
        Left = 1,
        Down = 2,
        Right = 3
    }

    /// <summary>
    /// a class representing a knight
    /// </summary>
    public class Knight
    {
        private KeyboardState keyboardState;

        private Texture2D body;
        private Texture2D feet;
        private Texture2D hands;
        private Texture2D head;
        private Texture2D legs;
        private Texture2D torso1;
        private Texture2D torso2;

        private double animationTimer;

        private short animationFrame = 0;

        public Direction Direction = Direction.Down;

        public Vector2 Position = new Vector2(200, 200);

        /// <summary>
        /// loads the knight texture
        /// </summary>
        /// <param name="content">the ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            body = content.Load<Texture2D>("walkcycle/BODY_male");
            feet = content.Load<Texture2D>("walkcycle/FEET_plate_armor_shoes");
            hands = content.Load<Texture2D>("walkcycle/HANDS_plate_armor_gloves");
            head = content.Load<Texture2D>("walkcycle/HEAD_plate_armor_helmet");
            legs = content.Load<Texture2D>("walkcycle/LEGS_plate_armor_pants");
            torso1 = content.Load<Texture2D>("walkcycle/TORSO_plate_armor_arms_shoulders");
            torso2 = content.Load<Texture2D>("walkcycle/TORSO_plate_armor_torso");
        }

        /// <summary>
        /// updates the sprite's position based on user input
        /// </summary>
        /// <param name="gameTime">the game time</param>
        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyDown(Keys.S))
            {
                Position += new Vector2(-.5f, .5f);
                Direction = Direction.Left;
            }
            else if (keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyDown(Keys.W))
            {
                Position += new Vector2(-.5f, -.5f);
                Direction = Direction.Left;
            }
            else if (keyboardState.IsKeyDown(Keys.D) && keyboardState.IsKeyDown(Keys.S))
            {
                Position += new Vector2(.5f, .5f);
                Direction = Direction.Right;
            }
            else if (keyboardState.IsKeyDown(Keys.D) && keyboardState.IsKeyDown(Keys.W))
            {
                Position += new Vector2(.5f, -.5f);
                Direction = Direction.Right;
            }
            else if (keyboardState.IsKeyDown(Keys.W))
            {
                Position += new Vector2(0, -1);
                Direction = Direction.Up;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                Position += new Vector2(0, 1);
                Direction = Direction.Down;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                Position += new Vector2(-1, 0);
                Direction = Direction.Left;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                Position += new Vector2(1, 0);
                Direction = Direction.Right;
            }
        }

        /// <summary>
        /// draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">the game time</param>
        /// <param name="spriteBatch">the spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.D))
            {
                //update animation timer
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                //update animation frame
                if (animationTimer > 0.15)
                {
                    animationFrame++;
                    if (animationFrame > 8) animationFrame = 1;
                    animationTimer -= 0.15;
                }

                //draw the sprite
                var source = new Rectangle(animationFrame * 64 + 16, (int)Direction * 64 + 14, 36, 50);
                spriteBatch.Draw(body, Position, source, Color.White);
                spriteBatch.Draw(feet, Position, source, Color.White);
                spriteBatch.Draw(legs, Position, source, Color.White);
                spriteBatch.Draw(torso1, Position, source, Color.White);
                spriteBatch.Draw(torso2, Position, source, Color.White);
                spriteBatch.Draw(head, Position, source, Color.White);
                spriteBatch.Draw(hands, Position, source, Color.White);

            }
            else
            {
                var source = new Rectangle(16, (int)Direction * 64 + 14, 36, 50);
                spriteBatch.Draw(body, Position, source, Color.White);
                spriteBatch.Draw(feet, Position, source, Color.White);
                spriteBatch.Draw(legs, Position, source, Color.White);
                spriteBatch.Draw(torso1, Position, source, Color.White);
                spriteBatch.Draw(torso2, Position, source, Color.White);
                spriteBatch.Draw(head, Position, source, Color.White);
                spriteBatch.Draw(hands, Position, source, Color.White);
            }
            
        }
    }
}
