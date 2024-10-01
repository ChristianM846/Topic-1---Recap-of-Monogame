using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Topic_1___Recap_of_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Texture2D> shipTextures = new List<Texture2D>();
        Random generator = new Random();

        Texture2D backgroundTexture;
        Rectangle backgroundRect;

        Texture2D shipTexture;
        Rectangle shipRect;

        SpriteFont titleFont;
        SpriteFont quoteFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            Window.Title = "Content, Scaling, and Text";

            shipRect = new Rectangle(generator.Next(0, 726), generator.Next(100, 401), 75, 100);

            backgroundRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("Images/space_background");

            for (int i = 1; i <= 5; i++)
            {
                shipTextures.Add(Content.Load<Texture2D>("Images/enterprise_" + i));
            }

            shipTexture = shipTextures[generator.Next(shipTextures.Count)];
            titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
            quoteFont = Content.Load<SpriteFont>("Fonts/QuoteFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, backgroundRect, Color.White);
            _spriteBatch.DrawString(titleFont, "Space", new Vector2(300, 10), Color.Yellow);
            _spriteBatch.DrawString(quoteFont, "Live long and prosper", new Vector2(250, 450), Color.Yellow);
            _spriteBatch.Draw(shipTexture, shipRect, null, Color.White, 1f, new Vector2(shipTexture.Width / 2, shipTexture.Height / 2), SpriteEffects.None, 1f);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
