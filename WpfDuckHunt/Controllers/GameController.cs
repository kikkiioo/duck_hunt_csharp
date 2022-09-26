using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDuckHunt.Models;
using Microsoft.Xna.Framework.Graphics;

namespace WpfDuckHunt.Controllers
{
    public class GameController
    {
        public static Game game = new Game();

        public static void newGame()
        {
            
            Dog dog = new Dog(x: 0, y: 320, state: EnumDogState.SNIFF, frame: 0, animation_duration: 0);
            game.Actors.Add(dog);

        }
        public static void updateControllers( float delta)
        {
            for (int i = 0; i < game.Actors.Count; i++)
            {
                if (game.Actors[i].GetType() == typeof(Dog))
                {
                    Dog dog = (Dog)game.Actors[i]; // nezinu kā šo apiet lai nebūtu jauns objekts jātaisa ? 

                    if (dog.State == EnumDogState.SNIFF)
                    {
                        DogController.sniff(dog, delta);
                    }
                }
            }
        }

        public static void updateActors(float delta)
        {
            for (int i = 0; i < game.Actors.Count; i++)
            {
                if (game.Actors[i].GetType() == typeof(Dog))
                {
                    Dog dog = (Dog)game.Actors[i]; // nezinu kā šo apiet lai nebūtu jauns objekts jātaisa ? 

                    if (dog.State == EnumDogState.SNIFF)
                    {

                        dog.animation_duration += delta;
                        dog.Frame += 8 * delta;
                        if (dog.Frame > 4)
                        {
                            dog.Frame = 0;
                        }
                        if (dog.animation_duration >= 4.5)
                        {
                            dog.State = EnumDogState.SNIFF1;
                            dog.animation_duration = 0;
                        }
                        Console.WriteLine(delta);

                    }

                    if (dog.State == EnumDogState.SNIFF1)
                    {
                        dog.Frame += 8 * delta;
                        
                        if (dog.Frame > 2)
                        {
                            dog.Frame = 0;
                        }
                        if (dog.animation_duration >= 0.5)
                        {
                            dog.State = EnumDogState.NOTHING;
                        }
                    }
                }
                
            }
        }
        
    }
}
