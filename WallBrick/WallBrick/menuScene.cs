using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WallBrick
{
    class menuScene : Scene
    {

        private Game game;
        private SpriteBatch spriteBatch;
        private XnaButton btn1;
        SpriteFont comicFont;
        Texture2D background;
        Rectangle logoPosition;

        public bool EndScene;
        public menuScene(Game game)
            : base(game)
        {
            this.game = game;
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
          
           
            btn1 = new XnaButton(game);
            btn1.Texture = game.Content.Load<Texture2D>("playNow");
            background = game.Content.Load<Texture2D>("arkanoidbg");
            btn1.Position = new Vector2(game.GraphicsDevice.Viewport.Width / 2 - btn1.Texture.Width / 4,210+ game.GraphicsDevice.Viewport.Height / 2 - btn1.Texture.Height);
            btn1.SourceRectangle = new Rectangle(0, 0, 400, btn1.Texture.Height);
            SceneComponents.Add(btn1);
            comicFont = game.Content.Load<SpriteFont>("MyFont");
            logoPosition = new Rectangle(0,0,800,450);

        }

        public override void Update(GameTime gameTime)
        {
            

            KeyboardState kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Down) && !btn1.IsSelected)
                btn1.IsSelected = true;
            else if (kbs.IsKeyDown(Keys.Up) && btn1.IsSelected)
                btn1.IsSelected = false;

            if (kbs.IsKeyDown(Keys.Enter) && btn1.IsSelected)
                this.EndScene = true;


            base.Update(gameTime);
        }
        public override void Initialize()
        {


            base.Initialize();
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(background, logoPosition, Color.White);
            spriteBatch.DrawString(comicFont, "Use Arrow keys to select, press ENTER to start the game. ", new Vector2(150, 450), Color.DarkMagenta);
            base.Draw(gameTime);
        }
    }
}
