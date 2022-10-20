using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
    [Serializable]
    public class Duck : Actor
    {
        public EnumDuckState State = EnumDuckState.NOTHING;
        public int score { get; set; }

        public EnumDuckFlyingDirection FlyingDirection = EnumDuckFlyingDirection.UP;
        public double Frame { get; set; }
        public float animation_duration { get; set; }

        public Duck (double x, double y, EnumDuckState state, int score, EnumDuckFlyingDirection FlyingDirection, double frame, float Animation_duration)
        {
            this.xPos = x;
            this.yPos = y;
            this.State = state;
            this.score = score;
            this.FlyingDirection = FlyingDirection;
            this.Frame = frame;
            this.animation_duration = Animation_duration;
        }
    }
}
