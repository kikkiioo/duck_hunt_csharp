using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
    [Serializable]
    
    public class Dog : Actor
    {
        public EnumDogState State = EnumDogState.NOTHING;
        public double Frame { get; set; }
        public float animation_duration { get; set; }

        public Dog(double x, double y,EnumDogState state, double frame, float Animation_duration){
            this.xPos = x;
            this.yPos = y;
            this.State = state;
            this.Frame = frame;
            this.animation_duration = Animation_duration;
            }
    }
}
