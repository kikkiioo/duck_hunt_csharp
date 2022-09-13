using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using duck_hunt_csharp.Models;

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

        public static void updateActors(Dog dog, float delta, float animation_duration)
        {
            
            if (dog.State == EnumDogState.SNIFF)
            {

                animation_duration += delta;
                dog.Frame += 8 * delta;
                if (dog.Frame > 3)
                {
                    dog.Frame = 0;
                }
                if(animation_duration >= 0.5)
                {
                    dog.State = EnumDogState.NOTHING;
                }
                
            }
        }
    }
}
