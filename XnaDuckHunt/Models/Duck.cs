using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
    public class Duck : Actor
    {
        public EnumDuckState State = EnumDuckState.NOTHING;
        public String DuckType { get; set; }
        public int score { get; set; }
        public String flyingDirection { get; set; }
        public double Frame { get; set; }
        public float animation_duration { get; set; }

        public Duck (double x, double y, EnumDuckState state, String duckType, int score, String FlyingDirection, double frame, float Animation_duration)
        {
            this.xPos = x;
            this.yPos = y;
            this.State = state;
            this.DuckType = duckType;
            this.score = score;
            this.flyingDirection = FlyingDirection;
            this.Frame = frame;
            this.animation_duration = Animation_duration;
        }
    }
}
