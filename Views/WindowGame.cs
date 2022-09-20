using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using duck_hunt_csharp.Models;
using duck_hunt_csharp.Controllers;
using System.Collections.Generic;

namespace duck_hunt_csharp
{
    public class WindowGame : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D background;
        Texture2D sniff1, sniff2, sniff3, sniff4, sniff5, sniff6;
        Dictionary<EnumDogState,List<Texture2D>> dictionary = new Dictionary<EnumDogState, List<Texture2D>>();
        List<Texture2D> sniff = new List<Texture2D>();
        public float animation_duration = 0 ;
        public float delta = 0;

        public WindowGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            background = Content.Load<Texture2D>("background");
            _graphics.PreferredBackBufferWidth = 550;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();

            sniff1 = Content.Load<Texture2D>("dog/sniff1");
            sniff2 = Content.Load<Texture2D>("dog/sniff2");
            sniff3 = Content.Load<Texture2D>("dog/sniff3");
            sniff4 = Content.Load<Texture2D>("dog/sniff4");
            sniff5 = Content.Load<Texture2D>("dog/sniff5");
            sniff6 = Content.Load<Texture2D>("dog/sniff6");
            List<Texture2D> sniff = new List<Texture2D>() { sniff1,sniff2,sniff3,sniff4};
            List<Texture2D> sniff_1 = new List<Texture2D>() { sniff5, sniff6 };
            dictionary.Add(EnumDogState.SNIFF, sniff);
            dictionary.Add(EnumDogState.SNIFF1, sniff_1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {

          
            delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            GameController.updateActors(delta);
            GameController.updateControllers(delta);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
         
            _spriteBatch.Draw(dictionary[dog.State][System.Convert.ToInt32(dog.Frame)], new Vector2((float)dog.xPos, (float)dog.yPos), Color.White);
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        
    }
}