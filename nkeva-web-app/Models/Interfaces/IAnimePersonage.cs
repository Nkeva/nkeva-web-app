using nkeva_web_app.Models.Anime;
using nkeva_web_app.Models.Enums;

namespace nkeva_web_app.Models.Interfaces
{
    public interface IAnimePersonage
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public AnimePersonageRole Role { get; set; }
        public Anime.Anime Anime { get; set; }
        public AnimeActor Actor { get; set; }
    }
}
