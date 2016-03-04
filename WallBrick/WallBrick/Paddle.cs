using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WallBrick
{
    class Paddle : DrawableGameComponent
    {

        Game game;
        SpriteBatch spriteBatch;
        Texture2D paddleSprite;
        Vector2 paddlePosition;
        public Rectangle paddleRect;

        public Paddle(Game game) :base(game)
        {
            this.game = game;
            paddleSprite = game.Content.Load<Texture2D>("snes");
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            paddlePosition = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - paddleSprite.Width / 2,
                                               game.GraphicsDevice.Viewport.Height - paddleSprite.Height);
            game.IsMouseVisible = true;


        }
        protected override void Dispose(bool disposing)
        {
            paddleSprite.Dispose();
            base.Dispose(disposing);
        }
        public override void Update(GameTime gameTime)
        {
            paddleRect = new Rectangle((int)paddlePosition.X, (int)paddlePosition.Y, paddleSprite.Width, paddleSprite.Height);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Right)) paddlePosition.X += 15;
            if (keyState.IsKeyDown(Keys.Left)) paddlePosition.X -= 15;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(paddleSprite, paddlePosition, Color.White);
            base.Draw(gameTime);
        }



    }
}
