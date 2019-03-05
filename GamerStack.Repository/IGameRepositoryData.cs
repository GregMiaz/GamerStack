using GamerStack.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamerStack.Repository
{
    public class IGameRepositoryData
    {
        private List<Game> _games;

        public IGameRepositoryData()
        {
            _games = new List<Game>()
            {
                new Game { GameId = 1, Title = "Destiny", Console = ConsoleType.PS4, Genre=Genre.Shooter, Description = "Great sci-fi uniwersum", IsFinished = true },
                new Game { GameId = 1, Title = "Demon's Souls", Console = ConsoleType.PS3, Genre = Genre.RPG, Description = "One of the hardest game challenges in fantasy world", IsFinished = true },
                new Game { GameId = 1, Title = "Uncharted: Golden Abyss", Console = ConsoleType.PSVita, Genre = Genre.Adventure, Description = "Beautiful hand-held adventure", IsFinished = true }
            };
        }

    }
}
