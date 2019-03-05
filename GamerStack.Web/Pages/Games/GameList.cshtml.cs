using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerStack.Models;
using GamerStack.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamerStack.Web.Pages.Games
{
    public class GameListModel : PageModel
    {
        private readonly IGameRepositoryData _gameRepositoryData;

        public IEnumerable<Game> Games { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public GameListModel(IGameRepositoryData gameRepositoryData)
        {
            _gameRepositoryData = gameRepositoryData;
        }

        public void OnGet()
        {
            Games = _gameRepositoryData.GetGamesByTitle(SearchValue);
        }
    }
}