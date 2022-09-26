using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duck_hunt_csharp.Models
{
    public class Game
    {
        public List<Actor> Actors { get; set; }
        public int level;
        public int score;
        public int shotCount;
        public Game()
        {
            this.Actors = new List<Actor>();
            this.level = 0;
            this.score = 0;
            this.shotCount = 0;
        }

    }
}
