using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace WallBrick
{
    class PongBall : DrawableGameComponent
    {
        Game game;
        SpriteBatch spriteBacth;
        Texture2D ballSprite;
        
        Vector2 ballPosition = new Vector2(225,150);
        public Vector2 ballSpeed = new Vector2(150, 150);
        public Rectangle ballRect;

        public PongBall(Game game): base(game){
                this.game = game;
                ballSprite = game.Content.Load<Texture2D>("Ping_pong_ball");
            
                spriteBacth = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));


        }


       


        protected override void Dispose(bool disposing)
        {
            ballSprite.Dispose();
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            ballPosition += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            int maxX = game.GraphicsDevice.Viewport.Width - ballSprite.Width;
            int maxY = game.GraphicsDevice.Viewport.Height - ballSprite.Height;

            if (ballPosition.X > maxX || ballPosition.X < 0) ballSpeed.X *= -1;
            if (ballPosition.Y < 0) ballSpeed.Y *= -1;
            else if (ballPosition.Y > maxY)
            {
                Game1.score -= 1;
              //  soundCenter.Crash.Play();
                ballPosition.Y = 150;
                ballSpeed.X = 150;
                ballSpeed.Y = 150;
            }
            ballRect = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);
        }

        public override void Draw(GameTime gameTime)
        {
            
            spriteBacth.Draw(ballSprite, ballPosition, Color.White);
           
            base.Draw(gameTime);
        }

    }
}
