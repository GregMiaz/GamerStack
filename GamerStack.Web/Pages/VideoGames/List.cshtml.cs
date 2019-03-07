﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamerStack.VideoGamesCore.Models;
using GamerStack.VideoGamesData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamerStack.Web.Pages.VideoGames
{
    public class ListModel : PageModel
    {
        private readonly IVideoGamesRepositoryData _videoGamesRepositoryData;

        public IEnumerable<VideoGame> VideoGames { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public ListModel(IVideoGamesRepositoryData videoGamesRepositoryData)
        {
            _videoGamesRepositoryData = videoGamesRepositoryData;
        }

        public void OnGet()
        {
            VideoGames = _videoGamesRepositoryData.GetVideoGamesByTitle(SearchValue);
        }
    }
}