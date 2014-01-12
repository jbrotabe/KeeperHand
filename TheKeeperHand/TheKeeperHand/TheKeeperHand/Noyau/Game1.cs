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

namespace TheKeeperHand
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // Fields.

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameMain main;

        private int sizeX, sizeY;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Noyau - The keeper hand";
            graphics.PreferredBackBufferWidth = 1120;
            graphics.PreferredBackBufferHeight = 640;
            this.sizeX = graphics.PreferredBackBufferWidth;
            this.sizeY = graphics.PreferredBackBufferHeight;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Ressources.LoadContent(Content);
            main = new GameMain(sizeX, sizeY);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            main.Update(gameTime, Keyboard.GetState(), Mouse.GetState());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            main.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
