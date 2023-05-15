using nkeva_web_app.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace nkeva_web_app.Models.Anime
{
    public class AnimePersonage
    { 

        [Key]
        public int Id { get; set; }
        [Required]
        public int AnimeId { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public AnimePersonageRole Role { get; set; }
        
        public Anime Anime { get; set; }
        public AnimeActor Actor { get; set; }
    }
}
