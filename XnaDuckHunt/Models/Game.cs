using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDuckHunt.Models
{
    public class Game
    {
        public List<Dog> dogActors { get; set; }
        public List<Duck> duckActors { get; set; }
        public int level;
        public int score;
        public int shotCount;
        public bool paused;
        public Game()
        {
            this.dogActors = new List<Dog>();
            this.duckActors = new List<Duck>();
            this.level = 0;
            this.score = 0;
            this.shotCount = 0;
            this.paused = false;
        }

    }
}
