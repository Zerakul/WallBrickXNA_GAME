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

namespace WallBrick
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        String msg="";
        Scene1 scene1;
        menuScene scene0;
       // SoundCenter soundCenter;
        SpriteFont comicFont;
        public static int score = 0;
        private bool loadonce = false;
        private TimeSpan time;

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
            //soundCenter = new SoundCenter(this);
            
            Services.AddService(typeof(SpriteBatch), spriteBatch);
         //   Services.AddService(typeof(SoundCenter), soundCenter);
            scene1 = new Scene1(this);
            scene0 = new menuScene(this);
            scene1.Hide();
            scene0.Show();
            Components.Add(scene1);
            Components.Add(scene0);
            comicFont =Content.Load<SpriteFont>("MyFontCopy");
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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (scene0.EndScene)
            {
                scene0.Hide();
                scene1.Show();
            }
             
            if (scene1.EndScene)
            {
                if (!loadonce)
                {
                    time = gameTime.TotalGameTime;
                    loadonce = true;
                }

                scene1.Pause();
                msg = "GAME OVER";

                if ((time.Seconds + 5) <gameTime.TotalGameTime.Seconds)
                {
                    scene0.EndScene = false;
                    Components.Remove(scene1);
                    scene1 = new Scene1(this);
                    scene1.Hide();
                    scene0.Show();
                    Components.Add(scene1);
                    msg = "";
                }
                
               
                

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {


            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            base.Draw(gameTime);
            spriteBatch.DrawString(comicFont, msg, new Vector2(185, 185), Color.Red);
            spriteBatch.End();
        }
    }
}
