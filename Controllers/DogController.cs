using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using duck_hunt_csharp.Models;

namespace duck_hunt_csharp.Controllers
{
    public class DogController
    {
        public static void sniff(Dog dog, float delta)
        {
            dog.xPos += 50 * delta;
        }
    }
}
