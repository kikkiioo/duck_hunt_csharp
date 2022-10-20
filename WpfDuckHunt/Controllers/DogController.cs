using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDuckHunt.Models;

namespace WpfDuckHunt.Controllers
{
    public class DogController
    {
        public static void sniff(Dog dog, float delta)
        {
            dog.xPos += 50 * delta;
        }
        public static void jumpUp(Dog dog, float delta)
        {
            dog.xPos += 50 * delta;
            dog.yPos -= 50 * delta;
        }
        public static void jumpDown(Dog dog, float delta)
        {
            dog.xPos += 50 * delta;
            dog.yPos += 50 * delta;
        }
    }
}
