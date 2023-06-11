using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Requests
{
    public class AnimeRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [StringLength(2048, MinimumLength = 0)]
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
        public int Episodes { get; set; }
        public double Rating { get; set; } = 0;
    }
}
