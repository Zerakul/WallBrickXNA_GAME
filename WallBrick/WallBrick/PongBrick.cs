using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WallBrick
{
    class PongBrick : DrawableGameComponent
    {

        Game game;
        SpriteBatch spriteBatch;
        Texture2D paddleSprite;
        Vector2 paddlePosition;
        public Rectangle paddleRect;
        private bool isSelcted;
        public PongBrick(Game game,float posx, float posy) : base(game)
        {
            this.game = game;
            paddleSprite = game.Content.Load<Texture2D>("65937");
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            paddlePosition = new Vector2(posx,posy);
            game.IsMouseVisible = true;
            SourceRectangle = new Rectangle(755,0,40,20) ;
            IsSelected = true;
            

        }

        public Rectangle? SourceRectangle { get; set; }
        protected override void Dispose(bool disposing)
        {
            paddleSprite.Dispose();
            base.Dispose(disposing);
        }

        public override void Update(GameTime gameTime)
        {
            //   paddleRect = new Rectangle((int)paddlePosition.X, (int)paddlePosition.Y, paddleSprite.Width, paddleSprite.Height);
            paddleRect = new Rectangle((int)paddlePosition.X, (int)paddlePosition.Y, 40, 20);
            base.Update(gameTime);
        }

        public bool IsSelected
        {
            get { return isSelcted; }
            set
            {

                isSelcted = value;
                SourceRectangle = isSelcted ? new Rectangle(755, 0, 40, 20) : new Rectangle(814, 0, 40, 20);

            }
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(paddleSprite, paddlePosition,SourceRectangle, Color.White);
            base.Draw(gameTime);
        }
    }

}
