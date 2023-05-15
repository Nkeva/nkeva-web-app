using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class AnimeGenre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Anime> Animes { get; set; } = new List<Anime>();
    }
}
