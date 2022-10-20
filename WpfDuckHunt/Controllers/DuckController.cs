using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDuckHunt.Models;

namespace WpfDuckHunt.Controllers
{
    public class DuckController
    {
        public static void flyRight(Duck duck, float delta)
        {
            if(duck.FlyingDirection == EnumDuckFlyingDirection.UP)
            {
                duck.xPos += 50 * delta;
                duck.yPos -= 50 * delta;
            }
            if(duck.FlyingDirection == EnumDuckFlyingDirection.DOWN)
            {
                duck.xPos -= 50 * delta;
                duck.yPos += 50 * delta;
            }
        }
        public static void flyLeft(Duck duck, float delta)
        {
            if (duck.FlyingDirection == EnumDuckFlyingDirection.UP)
            {
                duck.xPos -= 50 * delta;
                duck.yPos -= 50 * delta;
            }
            if (duck.FlyingDirection == EnumDuckFlyingDirection.DOWN)
            {
                duck.xPos -= 50 * delta;
                duck.yPos += 50 * delta;
            }
        }

        public static void fall(Duck duck, float delta)
        {
            duck.yPos += 50 * delta;
        }
    }
}
