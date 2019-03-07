using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamerStack.VideoGamesCore.Models
{
    public class VideoGame
    {
        public int VideoGameId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public ConsoleType Console { get; set; }
        public bool IsFinished { get; set; }
    }
}
