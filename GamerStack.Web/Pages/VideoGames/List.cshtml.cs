using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerStack.Models;
using GamerStack.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamerStack.Web.Pages.VideoGames
{
    public class ListModel : PageModel
    {
        private readonly IVideoGameRepositoryData _videoGameRepositoryData;

        public IEnumerable<VideoGame> VideoGames { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public ListModel(IVideoGameRepositoryData gameRepositoryData)
        {
            _videoGameRepositoryData = gameRepositoryData;
        }

        public void OnGet()
        {
            VideoGames = _videoGameRepositoryData.GetVideoGamesByTitle(SearchValue);
        }
    }
}