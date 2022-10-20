﻿using System;
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
            if(duck.flyingDirection == "up")
            {
                duck.xPos += 50 * delta;
                duck.yPos -= 50 * delta;
            }
            if(duck.flyingDirection == "down")
            {
                duck.xPos -= 50 * delta;
                duck.yPos += 50 * delta;
            }
        }
        public static void flyLeft(Duck duck, float delta)
        {
            if (duck.flyingDirection == "up")
            {
                duck.xPos -= 50 * delta;
                duck.yPos -= 50 * delta;
            }
            if (duck.flyingDirection == "down")
            {
                duck.xPos -= 50 * delta;
                duck.yPos += 50 * delta;
            }
        }
    }
}