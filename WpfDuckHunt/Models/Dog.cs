using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
    public class Dog : Actor
    {
        public EnumDogState State = EnumDogState.NOTHING;
        public double Frame { get; set; }
        public float animation_duration { get; set; }

        public Dog(double x, double y,EnumDogState state, double frame, float animation_duration){
            this.xPos = x;
            this.yPos = y;
            this.State = state;
            this.Frame = frame;
            this.animation_duration = animation_duration;
            }
    }
}
