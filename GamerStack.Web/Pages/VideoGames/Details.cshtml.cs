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
        private readonly IVideoGamesRepositoryData _videoGamesRepositoryData;

        public DetailsModel(IVideoGamesRepositoryData videoGamesRepositoryData)
        {
            _videoGamesRepositoryData = videoGamesRepositoryData;
        }

        public VideoGame VideoGame { get; set; }

        [TempData]
        public string Information { get; set; }

        public IActionResult OnGet(int videoGameId)
        {
            VideoGame = _videoGamesRepositoryData.GetVideoGameById(videoGameId);
            if (VideoGame == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }
    }
}