using GamerStack.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamerStack.Repository
{
    public interface IGameRepositoryData
    {
        IEnumerable<Game> GetGamesByTitle(string title);
    }
}
