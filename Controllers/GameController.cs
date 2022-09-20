using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using duck_hunt_csharp.Models;
using Microsoft.Xna.Framework.Graphics;

namespace duck_hunt_csharp.Controllers
{
    public class GameController
    {   
        
        
        public static void updateControllers(Dog dog, float delta)
        {
            if (dog.State == EnumDogState.SNIFF)
            {
                DogController.sniff(dog,delta);
            }
        }

        public static void updateActors(\GG F\\S dog, float delta, float animation_duration)
        {
            for (int i = 0; i < game.Actors.Count; i++)
            {

                if (dog.State == EnumDogState.SNIFF)
                {

                    animation_duration += delta;
                    dog.Frame += 8 * delta;
                    if (dog.Frame > 3)
                    {
                        dog.Frame = 0;
                    }
                    if (animation_duration >= 0.05)
                    {
                        dog.State = EnumDogState.SNIFF1;
                    }

                }
                if (dog.State == EnumDogState.SNIFF1)
                {
                    dog.Frame += 8 * delta;
                    if (dog.Frame > 1)
                    {
                        dog.Frame = 0;
                    }
                    if (animation_duration >= 0.5)
                    {
                        dog.State = EnumDogState.NOTHING;
                    }
                }
            }
        }
        public static void newGame()
        {
            Game game = new Game();
            Dog dog = new Dog(x: 0, y: 320, state: EnumDogState.SNIFF, frame: 0);
            game.Actors.Add(dog);

        }
    }
}
