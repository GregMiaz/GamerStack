using GamerStack.VideoGamesCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamerStack.VideoGamesData.Repository
{
    public interface IVideoGameRepositoryData
    {
        IEnumerable<VideoGame> GetVideoGamesByTitle(string title);
        VideoGame GetVideoGameById(int gameId);
    }
}
