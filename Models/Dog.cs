using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck_hunt_csharp.Models
{
    public class Dog : Actor
    {
        public EnumDogState State = EnumDogState.NOTHING;
        public double Frame { get; set; }
        public Dog(double x, double y,EnumDogState state, double frame){
            this.xPos = x;
            this.yPos = y;
            this.State = state;
            this.Frame = frame;
            }
    }
}
