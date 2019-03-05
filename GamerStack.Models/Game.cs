using System;
using System.Collections.Generic;
using System.Text;

namespace GamerStack.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public ConsoleType Console { get; set; }
        public bool IsFinished { get; set; }
    }
}
