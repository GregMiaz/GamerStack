using GamerStack.VideoGamesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamerStack.VideoGamesData.Repository
{
    public class MockVideoGameRepositoryData : IVideoGameRepositoryData
    {
        private List<VideoGame> _videoGames;

        public MockVideoGameRepositoryData()
        {
            _videoGames = new List<VideoGame>()
            {
                new VideoGame { VideoGameId = 1, Title = "Destiny", Console = ConsoleType.PS4, Genre=Genre.Shooter, Description = "Great sci-fi uniwersum", IsFinished = false },
                new VideoGame { VideoGameId = 2, Title = "Demon's Souls", Console = ConsoleType.PS3, Genre = Genre.RPG, Description = "One of the hardest game challenges in fantasy world", IsFinished = true },
                new VideoGame { VideoGameId = 3, Title = "Uncharted: Golden Abyss", Console = ConsoleType.PSVita, Genre = Genre.Adventure, Description = "Beautiful hand-held adventure", IsFinished = true }
            };
        }

        public IEnumerable<VideoGame> GetVideoGamesByTitle(string title)
        {
            return from g in _videoGames
                   where string.IsNullOrEmpty(title) || g.Title.StartsWith(title)
                   orderby g.Title
                   select g;
        }

        public VideoGame GetVideoGameById(int id)
                   => _videoGames.SingleOrDefault(g => g.VideoGameId == id);
    }
}
