using GamerStack.VideoGamesCore.Models;
using GamerStack.VideoGamesData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GamerStack.Web.Pages.VideoGames
{
    public class AddModel : PageModel
    {
        private readonly IVideoGamesRepositoryData _videoGamesRepositoryData;
        private readonly IHtmlHelper _htmlHelper;

        public AddModel(IVideoGamesRepositoryData videoGamesRepositoryData, IHtmlHelper htmlHelper)
        {
            _videoGamesRepositoryData = videoGamesRepositoryData;
            _htmlHelper = htmlHelper;
        }

        [BindProperty]
        public VideoGame VideoGame { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> ConsoleTypes { get; set; }

        public IActionResult OnGet()
        {
            Genres = _htmlHelper.GetEnumSelectList<Genre>();
            ConsoleTypes = _htmlHelper.GetEnumSelectList<ConsoleType>();

            VideoGame = new VideoGame();

            if (VideoGame == null)
            {
                return RedirectToPage("./PageNotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Genres = _htmlHelper.GetEnumSelectList<Genre>();
                ConsoleTypes = _htmlHelper.GetEnumSelectList<ConsoleType>();
                return Page();
            }
            _videoGamesRepositoryData.AddVideoGame(VideoGame);
            _videoGamesRepositoryData.SaveTransaction();
            TempData["Information"] = "Video Game successfully added to your collection!";
            return RedirectToPage("./Details", new { videoGameId = VideoGame.VideoGameId });
        }
    }
}