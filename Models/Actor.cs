using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck_hunt_csharp.Models
{
    public class Actor
    {
        public double xPos { get; set; }
        public double yPos { get; set; }
        public Actor(double x, double y)
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
