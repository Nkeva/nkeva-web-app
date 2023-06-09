﻿using nkeva_web_app.Models.Enums;
using nkeva_web_app.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class UserAnime : IUserAnime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int Rating { get; set; }
        [Required]
        public bool IsFavorite { get; set; }
        [Required]
        public AnimeWatchingState State { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int Rewatches { get; set; } = 0;
        public int EpisodesWatched { get; set; } = 0;
        [MaxLength(2048), MinLength(0)]
        public string Notes { get; set; } = "";

        public Anime Anime { get; set; }
        public User User { get; set; }
    }
}
