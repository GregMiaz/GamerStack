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
    public class GameDetailsModel : PageModel
    {
        private readonly IGameRepositoryData _gameRepositoryData;

        public GameDetailsModel(IGameRepositoryData gameRepositoryData)
        {
            _gameRepositoryData = gameRepositoryData;
        }

        public Game Game { get; set; }

        public IActionResult OnGet(int gameId)
        {
            Game = _gameRepositoryData.GetGameById(gameId);
            if (Game == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }
    }
}