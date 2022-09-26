using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Framework.WpfInterop.Input;
using MonoGame.Framework.WpfInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDuckHunt.Models;
using WpfDuckHunt.Controllers;

namespace WpfDuckHunt.Views
{
    public class MainGame : WpfGame
    {
        private GraphicsDeviceManager _graphics;
        private IGraphicsDeviceService _graphicsDeviceManager;
        private WpfKeyboard _keyboard;
        private WpfMouse _mouse;
        private SpriteBatch _spriteBatch;
        Texture2D background;
        Texture2D sniff1, sniff2, sniff3, sniff4, sniff5, sniff6;
        Dictionary<EnumDogState, List<Texture2D>> dictionary = new Dictionary<EnumDogState, List<Texture2D>>();
        List<Texture2D> sniff = new List<Texture2D>();

        public float delta = 0;

        /*public MainGame()
        {

            _graphicsDeviceManager = new WpfGraphicsDeviceService(this);

            Content.RootDirectory = "Content";
             GameController.newGame();
        }*/

        protected override void Initialize()
        {
           
            _graphicsDeviceManager = new WpfGraphicsDeviceService(this);
            
            /*_graphics.PreferredBackBufferWidth = 550;
            _graphics.PreferredBackBufferHeight = 480;
            _graphics.ApplyChanges();*/
            sniff1 = Content.Load<Texture2D>("dog/sniff1");
            sniff2 = Content.Load<Texture2D>("dog/sniff2");
            sniff3 = Content.Load<Texture2D>("dog/sniff3");
            sniff4 = Content.Load<Texture2D>("dog/sniff4");
            sniff5 = Content.Load<Texture2D>("dog/sniff5");
            sniff6 = Content.Load<Texture2D>("dog/sniff6");
            List<Texture2D> sniff = new List<Texture2D>() { sniff1, sniff2, sniff3, sniff4 };
            List<Texture2D> sniff_1 = new List<Texture2D>() { sniff5, sniff6 };
            dictionary.Add(EnumDogState.SNIFF, sniff);
            dictionary.Add(EnumDogState.SNIFF1, sniff_1);
            // must be initialized. required by Content loading and rendering (will add itself to the Services)
            // note that MonoGame requires this to be initialized in the constructor, while WpfInterop requires it to
            // be called inside Initialize (before base.Initialize())


            // wpf and keyboard need reference to the host control in order to receive input
            // this means every WpfGame control will have it's own keyboard & mouse manager which will only react if the mouse is in the control
            _keyboard = new WpfKeyboard(this);
            _mouse = new WpfMouse(this);

            // must be called after the WpfGraphicsDeviceService instance was created
            base.Initialize();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // content loading now possible
        }

        protected override void Update(GameTime time)
        {
            delta = (float)time.ElapsedGameTime.TotalSeconds;
            GameController.updateActors(delta);
            GameController.updateControllers(delta);
            base.Update(time);

            // every update we can now query the keyboard & mouse for our WpfGame
            var mouseState = _mouse.GetState();
            var keyboardState = _keyboard.GetState();
        }

        protected override void Draw(GameTime time)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            
            for (int i = 0; i < GameController.game.Actors.Count; i++)
            {
                if (GameController.game.Actors[i].GetType() == typeof(Dog))
                {
                    Dog dog = (Dog)GameController.game.Actors[i]; // nezinu kā šo apiet lai nebūtu jauns objekts jātaisa ? 

                    _spriteBatch.Draw(dictionary[dog.State][(int)(dog.Frame)], new Vector2((float)dog.xPos, (float)dog.yPos), Color.White);

                }

            }
            _spriteBatch.End();
            base.Draw(time);
        }
    }
}
