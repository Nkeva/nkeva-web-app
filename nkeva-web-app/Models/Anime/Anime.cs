﻿using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class Anime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required, MaxLength(2048)]
        public string Description { get; set; }
        [Required]
        public string TitleImage { get; set; }
        [Required]
        public string BackgroundImage { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int FormatId { get; set; }
        [Required]
        public int Episodes { get; set; } = 0;
        public double Rating { get; set; } = 0;
        public AnimeGenre Genre { get; set; }
        public AnimeFormat Format { get; set; }

        public virtual ICollection<AnimePersonage> Personages { get; set; } = new List<AnimePersonage>();
        public virtual ICollection<AnimeComment> Comments { get; set; } = new List<AnimeComment>();
        public virtual ICollection<UserAnime> UserAnimes { get; set;} = new List<UserAnime>();
    }
}
