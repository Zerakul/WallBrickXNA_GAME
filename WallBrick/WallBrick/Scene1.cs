using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WallBrick
{
    class Scene1:Scene
    {

        private Game game;
        private SpriteBatch spriteBatch;
        private PongBall ballSprite;
        private Paddle paddleSprite;
        private PongBrick [,]bricks =new PongBrick[20,7];
        Texture2D background;
        Rectangle bgPos;
        SpriteFont comicFont;
        private string msg="";
        bool isBricksLeft = false;
        private TimeSpan time;
        private bool loadonce = false;
        // private SoundCenter soundCenter;
        public bool EndScene;
        public Scene1(Game game)
            : base(game)
        {
            this.game = game;
            
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
          //  soundCenter = (SoundCenter)game.Services.GetService(typeof(SoundCenter));
            ballSprite = new PongBall(game);
            paddleSprite = new Paddle(game);
            SceneComponents.Add(ballSprite);
            SceneComponents.Add(paddleSprite);
            bgPos = new Rectangle(0,0,game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);
           // msg = "" + game.GraphicsDevice.Viewport.Width;
            
            //btn1 = new XnaButton(game);
            //btn1.Texture = game.Content.Load<Texture2D>("playNow");
            //btn1.Position = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - btn1.Texture.Width / 4, game.GraphicsDevice.Viewport.Height / 2-btn1.Texture.Height);
            //btn1.SourceRectangle = new Rectangle(0, 0, 400, btn1.Texture.Height);
            //SceneComponents.Add(btn1);

            EndScene = false;
            for (int i = 0; i < bricks.GetLength(0); i++)
            {
                for (int j = 0; j < bricks.GetLength(1); j++)
                {
                    bricks[i,j] = new PongBrick(game, i * 40, j * 20);
                    SceneComponents.Add(bricks[i,j]);
                }
            }

            comicFont = game.Content.Load<SpriteFont>("MyFont");
            background = game.Content.Load<Texture2D>("breakout");

        }

        public override void Update(GameTime gameTime)
        {
            if (ballSprite.ballRect.Intersects(paddleSprite.paddleRect) && ballSprite.ballSpeed.Y > 0)
            {
                //Game1.score += 5;
                //soundCenter.Swish.Play();
                ballSprite.ballSpeed.Y += 20;
                if (ballSprite.ballSpeed.X < 0) ballSprite.ballSpeed.X -= 20;
                else ballSprite.ballSpeed.X += 20;
                ballSprite.ballSpeed.Y *= -1;
            }
            for (int i = 0; i < bricks.GetLength(0); i++) {
                for (int j = 0; j < bricks.GetLength(1); j++)
                {
                    if (bricks[i,j] != null)
                        if (ballSprite.ballRect.Intersects(bricks[i,j].paddleRect))
                        {
                            if (bricks[i, j].IsSelected)
                            {

                                bricks[i, j].IsSelected = false;

                            }
                            else {
                                bricks[i, j].Visible = false;
                                bricks[i, j] = null;
                            }
                            
                            ballSprite.ballSpeed.X *= (float)-1;
                            ballSprite.ballSpeed.Y *= (float)-1;
                            Game1.score++;
                            
                        }
                }

                    }

            for (int i = 0; i < bricks.GetLength(0); i++)
            {
                for (int j = 0; j < bricks.GetLength(1); j++)
                {
                    if (bricks[i, j]!=null)
                        isBricksLeft = true;
                }

            }

            if (!isBricksLeft)
                this.EndScene = true;

            isBricksLeft = false;

            if (!loadonce)
            {
                time = gameTime.TotalGameTime;
                loadonce = true;
            }

            if ((time.Seconds + 20) < gameTime.TotalGameTime.Seconds)
            {
                
                msg = "Press 'F' to FINISH the game.";
            }

            KeyboardState kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.F))
                cheatActivated();


                base.Update(gameTime);
        }

        private void cheatActivated()
        {
            for (int i = 0; i < bricks.GetLength(0); i++)
            {
                for (int j = 0; j < bricks.GetLength(1); j++)
                {
                    if (bricks[i, j] != null)
                    {
                        bricks[i, j].Visible = false;
                        bricks[i, j] = null;
                    }
                }

            }
        }

        public override void Initialize()
        {
           

            base.Initialize();
        }
        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.LightGreen);
            spriteBatch.Draw(background,bgPos,Color.White);
             spriteBatch.DrawString(comicFont,"My Score:" + Game1.score, new Vector2(2,450), Color.Gold);

             spriteBatch.DrawString(comicFont, msg , new Vector2(520, 450), Color.LightYellow);
            base.Draw(gameTime);
        }
    }
}
