using GamerStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamerStack.Repository
{
    public class MockGameRepositoryData : IGameRepositoryData
    {
        private List<Game> _games;

        public MockGameRepositoryData()
        {
            _games = new List<Game>()
            {
                new Game { GameId = 1, Title = "Destiny", Console = ConsoleType.PS4, Genre=Genre.Shooter, Description = "Great sci-fi uniwersum", IsFinished = false },
                new Game { GameId = 2, Title = "Demon's Souls", Console = ConsoleType.PS3, Genre = Genre.RPG, Description = "One of the hardest game challenges in fantasy world", IsFinished = true },
                new Game { GameId = 3, Title = "Uncharted: Golden Abyss", Console = ConsoleType.PSVita, Genre = Genre.Adventure, Description = "Beautiful hand-held adventure", IsFinished = true }
            };
        }

        public IEnumerable<Game> GetGamesByTitle(string title)
        {
            return from g in _games
                   where string.IsNullOrEmpty(title) || g.Title.StartsWith(title)
                   orderby g.Title
                   select g;
        }

        public Game GetGameById(int gameId)
                   => _games.SingleOrDefault(g => g.GameId == gameId);
    }
}
