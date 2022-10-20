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
        private SpriteBatch _spriteBatch;
        Texture2D background;
        Texture2D sniff1, sniff2, sniff3, sniff4, sniff5, sniff6, jump1, jump2;
        Texture2D fly1, fly2, fly3, fly4, fly5, fly6,die1,die2,die3;
        Dictionary<Enum, List<Texture2D>>_textures_by_player_state = new Dictionary <Enum, List<Texture2D>>();
        public float delta = 0;
 

        public MainGame()
        {
             GameController.newGame();

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
            List<Texture2D> _textures_anim_sniff_dog = new List<Texture2D>() { sniff1, sniff2, sniff3, sniff4 };
            List<Texture2D > _textures_anim_sniff1_dog = new List<Texture2D>() { sniff5, sniff6 };
            List<Texture2D> _textures_anim_jump_dog = new List<Texture2D>() { jump1, jump2 };

            _textures_by_player_state.Add(EnumDogState.SNIFF, _textures_anim_sniff_dog);
            _textures_by_player_state.Add(EnumDogState.SNIFF1, _textures_anim_sniff1_dog);
            _textures_by_player_state.Add(EnumDogState.JUMP_UP, _textures_anim_jump_dog);
            _textures_by_player_state.Add(EnumDogState.JUMP_DOWN, _textures_anim_jump_dog);
         

            // graphics for duck //
            fly1 = getContent("duck/blackDuck/fly1.png");
            fly2 = getContent("duck/blackDuck/fly2.png");
            fly3 = getContent("duck/blackDuck/fly3.png");
            fly4 = getContent("duck/blackDuck/fly4.png");
            fly5 = getContent("duck/blackDuck/fly5.png");
            fly6 = getContent("duck/blackDuck/fly6.png");
            die1 = getContent("duck/blackDuck/die1.png");
            die2 = getContent("duck/blackDuck/die2.png");
            die3 = getContent("duck/blackDuck/die3.png");
            List<Texture2D> _textures_anim_rightFly_duck = new List<Texture2D> { fly1, fly2, fly3 };
            List<Texture2D> _textures_anim_leftFly_duck = new List<Texture2D> { fly4,fly5, fly6 };
            List<Texture2D> _textures_anim_die_duck = new List<Texture2D> { die1 };
            List<Texture2D> _textures_anim_fall_duck = new List<Texture2D> { die2, die3 };
            _textures_by_player_state.Add(EnumDuckState.RIGHTFLY, _textures_anim_rightFly_duck);
            _textures_by_player_state.Add(EnumDuckState.LEFTFLY, _textures_anim_leftFly_duck);
            _textures_by_player_state.Add(EnumDuckState.DIE, _textures_anim_die_duck);
            _textures_by_player_state.Add(EnumDuckState.FALL, _textures_anim_fall_duck);

            base.Initialize();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
 
        }
        Texture2D getContent(String content)
        {
            Texture2D texture;
            using (FileStream filestream = new FileStream("./graphics/"+content, FileMode.Open))
            {
                texture = Texture2D.FromStream(GraphicsDevice, filestream);
            }
            return texture;
        }
        protected override void Update(GameTime time)
        {

            if (GameController.getGame().paused == false)
            {
                delta = (float)time.ElapsedGameTime.TotalSeconds;
                GameController.updateActors(delta);
                GameController.updateControllers(delta);
                base.Update(time);
            }
       
        }

        protected override void Draw(GameTime time)
        {

            if (GameController.getGame().paused == false)

            {
                _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0, 0), Color.White);


                foreach(var dogActor in GameController.getGame().dogActors)
                {
                    if (dogActor.State == EnumDogState.NOTHING)
                    {
                        break;
                    }
                    _spriteBatch.Draw(_textures_by_player_state[dogActor.State][(int)(dogActor.Frame)], new Vector2((float)dogActor.xPos, (float)dogActor.yPos), Color.White);
                }
                foreach(var duckActor in GameController.getGame().duckActors)
                {
                   
                    if (duckActor.State == EnumDuckState.NOTHING)
                    {
                        break;
                    }
                    _spriteBatch.Draw(_textures_by_player_state[duckActor.State][(int)(duckActor.Frame)], new Vector2((float)duckActor.xPos, (float)duckActor.yPos), Color.White);

                }
                _spriteBatch.End();
                base.Draw(time);
            }
        }
    }
}
