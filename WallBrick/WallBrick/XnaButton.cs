using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WallBrick
{
    class XnaButton : DrawableGameComponent
    {
        bool isSelcted = false;


  
        public XnaButton(Game game):base(game)
        {
            SpriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            SourceRectangle = null;
            
        }

        public Rectangle? SourceRectangle { get; set; }
        public Texture2D Texture { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        public Vector2 Position { get; set; }

        public bool IsSelected { get { return isSelcted; } set {

                isSelcted = value;
                SourceRectangle = isSelcted ? new Rectangle(400, 0, 400, Texture.Height) : new Rectangle(0,0,400, Texture.Height);

            } }

        public override void Draw(GameTime gameTime)
        {
            
            SpriteBatch.Draw(Texture,Position,SourceRectangle,Color.White);
          
            base.Update(gameTime);
        }
    }
}
