using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck_hunt_csharp.Models
{
    public class Actor
    {
        public Double xPos { get; set; }
        public Double yPos { get; set; }
        public Actor(Double x, Double y)
        {
            this.xPos = x;
            this.yPos = y;
        }
        public Actor()
        {
            xPos = 0;
            yPos = 0;
        }
    }
}
