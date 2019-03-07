using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerStack.VideoGamesCore.Models;
using GamerStack.VideoGamesData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamerStack.Web.Pages.VideoGames
{
    public class EditModel : PageModel
    {
        private readonly IVideoGamesRepositoryData _videoGamesRepositoryData;
        private readonly IHtmlHelper _htmlHelper;

        public VideoGame VideoGame { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> ConsoleTypes { get; set; }
        

        public EditModel(IVideoGamesRepositoryData videoGamesRepositoryData, IHtmlHelper htmlHelper)
        {
            _videoGamesRepositoryData = videoGamesRepositoryData;
            _htmlHelper = htmlHelper;
        }

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
    }
}