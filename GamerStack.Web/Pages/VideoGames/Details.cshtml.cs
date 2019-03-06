using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerStack.VideoGamesCore.Models;
using GamerStack.VideoGamesData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamerStack.Web.Pages.VideoGames
{
    public class DetailsModel : PageModel
    {
        private readonly IVideoGameRepositoryData _videoGameRepositoryData;

        public DetailsModel(IVideoGameRepositoryData gameRepositoryData)
        {
            _videoGameRepositoryData = gameRepositoryData;
        }

        public VideoGame VideoGame { get; set; }

        public IActionResult OnGet(int videoGameId)
        {
            VideoGame = _videoGameRepositoryData.GetVideoGameById(videoGameId);
            if (VideoGame == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }
    }
}