using GamerStack.VideoGamesCore.Models;
using GamerStack.VideoGamesData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GamerStack.Web.Pages.VideoGames
{
    public class EditModel : PageModel
    {
        private readonly IVideoGamesRepositoryData _videoGamesRepositoryData;
        private readonly IHtmlHelper _htmlHelper;

        public EditModel(IVideoGamesRepositoryData videoGamesRepositoryData, IHtmlHelper htmlHelper)
        {
            _videoGamesRepositoryData = videoGamesRepositoryData;
            _htmlHelper = htmlHelper;
        }

        [BindProperty]
        public VideoGame VideoGame { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> ConsoleTypes { get; set; }

        public IActionResult OnGet(int videoGameId)
        {
            VideoGame = _videoGamesRepositoryData.GetVideoGameById(videoGameId);
            Genres = _htmlHelper.GetEnumSelectList<Genre>();
            ConsoleTypes = _htmlHelper.GetEnumSelectList<ConsoleType>();
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
            _videoGamesRepositoryData.EditVideoGame(VideoGame);
            _videoGamesRepositoryData.SaveTransaction();
            TempData["Information"] = "Video Game was successfully edited!";
            return RedirectToPage("./Details", new { videoGameId = VideoGame.VideoGameId });
        }
    }
}