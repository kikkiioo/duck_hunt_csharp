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
using System.IO;

namespace WpfDuckHunt.Views
{
    public class MainGame : WpfGame
    {
        
        private IGraphicsDeviceService _graphicsDeviceManager;
        private WpfKeyboard _keyboard;
        private WpfMouse _mouse;
        private SpriteBatch _spriteBatch;
        Texture2D background;
        Texture2D sniff1, sniff2, sniff3, sniff4, sniff5, sniff6, jump1, jump2;
        Texture2D fly1, fly2, fly3, fly4, fly5, fly6,die1,die2,die3;
        Dictionary<Enum, List<Texture2D>> dictionary = new Dictionary<Enum, List<Texture2D>>();
        List<Texture2D> sniff = new List<Texture2D>();

        public float delta = 0;
        Texture2D texture;

        public MainGame()
        {
             GameController.newGame();

        }
        public static void getMousePos()
        {
            
        }
        protected override void Initialize()
        {
           
            _graphicsDeviceManager = new WpfGraphicsDeviceService(this);

            
            background = getContent("background.png");
            /// graphics for dog
            sniff1 = getContent("dog/sniff1.png");
            sniff2 = getContent("dog/sniff2.png");
            sniff3 = getContent("dog/sniff3.png");
            sniff4 = getContent("dog/sniff4.png");
            sniff5 = getContent("dog/sniff5.png");
            sniff6 = getContent("dog/sniff6.png");
            jump1 = getContent("dog/jump2.png");
            jump2 = getContent("dog/jump3.png");
            List<Texture2D> sniff = new List<Texture2D>() { sniff1, sniff2, sniff3, sniff4 };
            List<Texture2D> sniff_1 = new List<Texture2D>() { sniff5, sniff6 };
            List<Texture2D> jump = new List<Texture2D>() { jump1, jump2 };

            dictionary.Add(EnumDogState.SNIFF, sniff);
            dictionary.Add(EnumDogState.SNIFF1, sniff_1);
            dictionary.Add(EnumDogState.JUMP_UP, jump);
            dictionary.Add(EnumDogState.JUMP_DOWN, jump);

            // graphics for duck //
            fly1 = getContent("duck/blackDuck/fly1.png");
            fly2 = getContent("duck/blackDuck/fly2.png");
            fly3 = getContent("duck/blackDuck/fly3.png");
            fly4 = getContent("duck/blackDuck/fly4.png");
            fly5 = getContent("duck/blackDuck/fly5.png");
            fly6 = getContent("duck/blackDuck/fly6.png");
            die1 = getContent("duck/blackDuck/die1.png");
            die2 = getContent("duck/blackDuck/die1.png");
            die3 = getContent("duck/blackDuck/die1.png");
            List<Texture2D> rightFly = new List<Texture2D> { fly1, fly2, fly3 };
            List<Texture2D> leftFly = new List<Texture2D> { fly4,fly5, fly6 };
            List<Texture2D> die = new List<Texture2D> { die1, die2, die3 };
            dictionary.Add(EnumDuckState.RIGHTFLY, rightFly);
            dictionary.Add(EnumDuckState.LEFTFLY, leftFly);
           dictionary.Add(EnumDuckState.DIE, die);
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
        Texture2D getContent(String content)
        {
            using (FileStream filestream = new FileStream("./graphics/"+content, FileMode.Open))
            {
                texture = Texture2D.FromStream(GraphicsDevice, filestream);
            }
            return texture;
        }
        protected override void Update(GameTime time)
        {
            if (GameController.game.paused == false)
            {
                delta = (float)time.ElapsedGameTime.TotalSeconds;
                GameController.updateActors(delta);
                GameController.updateControllers(delta);
                base.Update(time);
            }
            // every update we can now query the keyboard & mouse for our WpfGame
            var mouseState = _mouse.GetState();
            var keyboardState = _keyboard.GetState();
        }

        protected override void Draw(GameTime time)
        {
            if (GameController.game.paused == false)
            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);


                for (int i = 0; i < GameController.game.dogActors.Count; i++)
                {
                    if (GameController.game.dogActors[i].State == EnumDogState.NOTHING)
                    {
                        break;
                    }
                    _spriteBatch.Draw(dictionary[GameController.game.dogActors[i].State][(int)(GameController.game.dogActors[i].Frame)], new Vector2((float)GameController.game.dogActors[i].xPos, (float)GameController.game.dogActors[i].yPos), Color.White);
                }
                for (int i = 0; i < GameController.game.duckActors.Count; i++)
                {
                    if (GameController.game.duckActors[i].State == EnumDuckState.NOTHING)
                    {
                        break;
                    }
                    _spriteBatch.Draw(dictionary[GameController.game.duckActors[i].State][(int)(GameController.game.duckActors[i].Frame)], new Vector2((float)GameController.game.duckActors[i].xPos, (float)GameController.game.duckActors[i].yPos), Color.White);
                }
                _spriteBatch.End();
                base.Draw(time);
            }
        }
    }
}
