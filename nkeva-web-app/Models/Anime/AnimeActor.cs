using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class AnimeActor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual ICollection<AnimePersonage> Personages { get; set; } = new List<AnimePersonage>();
    }
}
