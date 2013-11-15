using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PizzaGuy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pacmanSheet;
        PizzaGuy pacman;
        private Rectangle pacmanAreaLimit;
        Vector2 destination;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pacmanSheet = Content.Load<Texture2D>(@"pacman");

            pacman = new PizzaGuy(new Vector2(300, 300), pacmanSheet, new Rectangle(5, 26, 17, 17), Vector2.Zero);
            pacman.AddFrame(new Rectangle(25,25,15,17));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        private void HandleKeyboardInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Up))
            {
                pacman.Velocity += new Vector2(0, -100);
                pacman.Rotation = MathHelper.PiOver2;
                destination = pacman.Location - new Vector2(0, -32);

                pacman.direction = Direction.UP;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                pacman.Velocity += new Vector2(0, 100);
                pacman.Rotation = -MathHelper.PiOver2;
                destination = pacman.Location - new Vector2(0, 32);

                pacman.direction = Direction.DOWN;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                pacman.Velocity += new Vector2(-100, 0);
                pacman.Rotation = 0f;
                destination = pacman.Location - new Vector2(-32, 0);

                pacman.direction = Direction.LEFT;
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                pacman.Velocity += new Vector2(100, 0);
                pacman.Rotation = MathHelper.PiOver2;
                destination = pacman.Location - new Vector2(32, 0);

                pacman.direction = Direction.RIGHT;
            }

            if (pacman.Velocity.X > 0 && pacman.Location.X >= destination.X ||
               pacman.Velocity.X < 0 && pacman.Location.X <= destination.X ||
               pacman.Velocity.Y >  0 && pacman.Location.Y >= destination.Y  ||
               pacman.Velocity.Y < 0 && pacman.Location.Y <= destination.Y)
            {
                pacman.Velocity = new Vector2(0, 0);
                //pacman.Location = destination;
            }

            else
            {
                pacman.Velocity = new Vector2(0, 0);
            }
        }

        private void imposeMovementLimits()
        {
            Vector2 location = pacman.Location;

            if (location.X < pacmanAreaLimit.X)
                location.X = pacmanAreaLimit.X;

            if (location.X >
                (pacmanAreaLimit.Right - pacman.Source.Width))
                location.X =
                    (pacmanAreaLimit.Right - pacman.Source.Width);

            if (location.Y < pacmanAreaLimit.Y)
                location.Y = pacmanAreaLimit.Y;

            if (location.Y >
                (pacmanAreaLimit.Bottom - pacman.Source.Height))
                location.Y =
                    (pacmanAreaLimit.Bottom - pacman.Source.Height);

            pacman.Location = location;
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            pacman.Update(gameTime);
            HandleKeyboardInput(Keyboard.GetState());
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            pacman.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
