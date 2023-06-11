using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nkeva_web_app.Attributes;
using nkeva_web_app.Models;
using nkeva_web_app.Models.Anime;
using nkeva_web_app.Requests;
using nkeva_web_app.Responses;

namespace nkeva_web_app.Controllers
{
    [Route("api/animes")]
    [Authorize]
    [ApiController]
    public class AnimeController : BaseController
    {
        public AnimeController(DbApp context) : base(context)
        {
        }

        // animes

        [OnlyStaffAuthorize]
        [HttpPost]
        public async Task<IActionResult> AddAnimeToMainList([FromBody] AnimeRequest request)
        {
            AnimeGenre? genre = await DB.AnimeGenres.SingleOrDefaultAsync(p => p.Id == request.GenreId);
            AnimeFormat? format = await DB.AnimeFormats.SingleOrDefaultAsync(p => p.Id == request.FormatId);

            if (genre != null && format != null)
            {
                Anime newAnime = (await DB.Animes.AddAsync(new Anime
                {
                    Name = request.Name,
                    Year = request.Year,
                    Description = request.Description,
                    TitleImage = request.TitleImage,
                    BackgroundImage = request.BackgroundImage,
                    GenreId = request.GenreId,
                    FormatId = request.FormatId,
                    Episodes = request.Episodes,
                    Rating = request.Rating,
                    Genre = genre,
                    Format = format
                })).Entity;

                await DB.SaveChangesAsync();

                return Ok(new AnimeResponse(true, null, newAnime));
            }

            return BadRequest(new AnimeResponse(false, "Invalid anime genre or format!"));
        }

        [HttpGet]
        public async Task<IActionResult> GetFullAnimeList()
        {
            List<Anime> list = await DB.Animes
                .Include(p => p.Genre)
                .Include(p => p.Format)
                .OrderBy(p => p.Name)
                .ToListAsync();

            return Ok(new ListResponse<Anime>(true, null, list));
        }

        [HttpGet("id-list")]
        public async Task<IActionResult> GetFullAnimeIdList()
        {
            List<int> idList = await DB.Animes.Select(e => e.Id).ToListAsync();

            return Ok(new ListResponse<int>(true, null, idList));
        }

        [HttpGet("{animeID}")]
        public async Task<IActionResult> GetAnime(int animeID)
        {
            Anime? result = await DB.Animes
                .Include(p => p.Genre)
                .Include(p => p.Format)
                .SingleOrDefaultAsync(p => p.Id == animeID);

            return result != null
                ? Ok(new AnimeResponse(true, null, result))
                : NotFound(new AnimeResponse(false, "Invalid id input!"));
        }

        [OnlyStaffAuthorize]
        [HttpPut("{animeID}")]
        public async Task<IActionResult> UpdateAnimeInfo(int animeID, [FromBody] AnimeRequest request)
        {
            int? foundAnimeID = await DB.Animes
                .Select(p => p.Id)
                .SingleOrDefaultAsync(p => p == animeID);

            if (foundAnimeID == null)
            {
                return NotFound(new AnimeResponse(false, "Invalid anime id!"));
            }

            AnimeGenre? genre = await DB.AnimeGenres.SingleOrDefaultAsync(p => p.Id == request.GenreId);
            AnimeFormat? format = await DB.AnimeFormats.SingleOrDefaultAsync(p => p.Id == request.FormatId);

            if (genre == null || format == null)
            {
                return NotFound(new AnimeResponse(false, "Invalid genre id or format id!"));
            }

            Anime newAnime = DB.Animes.Update(new Anime
            {
                Name = request.Name,
                Year = request.Year,
                Description = request.Description,
                TitleImage = request.TitleImage,
                BackgroundImage = request.BackgroundImage,
                GenreId = request.GenreId,
                FormatId = request.FormatId,
                Episodes = request.Episodes,
                Rating = request.Rating,
                Genre = genre,
                Format = format
            }).Entity;

            await DB.SaveChangesAsync();

            return Ok(new AnimeResponse(true, null, newAnime));
        }

        [OnlyStaffAuthorize]
        [HttpDelete("{animeID}")]
        public async Task<IActionResult> DeleteAnimeFromMainList(int animeID)
        {
            Anime? anime = await DB.Animes.SingleOrDefaultAsync(p => p.Id == animeID);

            if (anime == null)
            {
                return NotFound(new AnimeResponse(false, "Invalid anime id!"));
            }

            anime = DB.Animes.Remove(anime).Entity;

            await DB.SaveChangesAsync();

            return Ok(new AnimeResponse(true, null, anime));
        }

        // anime genres

        [HttpGet("genres")]
        public async Task<IActionResult> GetAnimeGenreList()
        {
            List<AnimeGenre> list = await DB.AnimeGenres
                .OrderBy(p => p.Name)
                .ToListAsync();

            return Ok(new ListResponse<AnimeGenre>(true, null, list));
        }

        // anime formats

        [HttpGet("formats")]
        public async Task<IActionResult> GetAnimeFormatList()
        {
            List<AnimeFormat> list = await DB.AnimeFormats
                .OrderBy(p => p.Name)
                .ToListAsync();

            return Ok(new ListResponse<AnimeFormat>(true, null, list));
        }

        // anime personages

        [HttpGet("personages/from-anime/{animeID}")]
        public async Task<IActionResult> GetPersonageListByAnime(int animeID, [FromQuery] string? getAnime = null)
        {
            List<AnimePersonage> personages = await DB.AnimePersonages
                .Include(p => p.Anime)
                .Include(p => p.Actor)
                .Where(p => p.AnimeId == animeID)
                .ToListAsync();

            if (getAnime == "true")
            {
                return Ok(new ListResponse<AnimePersonage>(true, null, personages));
            }

            var formattedPersonages = new List<AnimePersonageResponse.AnimePersonage>();

            foreach (var el in personages)
            {
                formattedPersonages.Add(new AnimePersonageResponse.AnimePersonage(el));
            }

            return Ok(new ListResponse<AnimePersonageResponse.AnimePersonage>(true, null, formattedPersonages));
        }

        // comments for animes

        [HttpPost("comments")]
        public async Task<IActionResult> CreateAnimeComment([FromBody] AnimeCommentRequest request)
        {
            Anime? anime = await DB.Animes
                .Include(p => p.Genre)
                .Include(p => p.Format)
                .SingleOrDefaultAsync(p => p.Id == request.AnimeId);

            User? user = await DB.Users.SingleOrDefaultAsync(p => p.Id == request.WriterId);

            if (user != null && anime != null)
            {
                AnimeComment newComment = (await DB.AnimeComments.AddAsync(new AnimeComment
                {
                    AnimeId = request.AnimeId,
                    WriterId = request.WriterId,
                    Comment = request.Comment,
                    Date = request.Date,
                    Anime = anime,
                    Writer = user
                })).Entity;

                await DB.SaveChangesAsync();

                return Ok(new AnimeCommentResponse(true, null, newComment));
            }

            return BadRequest(new AnimeCommentResponse(false, "Invalid anime or user"));
        }

        [HttpGet("comments/from-anime/{animeID}")]
        public IActionResult GetCommentListByAnime(int animeID, [FromQuery] bool? getAnime = null)
        {
            var data = from comment in DB.AnimeComments
                       where comment.AnimeId == animeID
                       join commentReaction in DB.AnimeCommentReactions on comment.Id equals commentReaction.CommentId into reactionsGroup
                       select new
                       {
                           Comment = comment,
                           Reactions = new
                           {
                               Like = reactionsGroup.Count(p => p.Liked),
                               Dislike = reactionsGroup.Count(p => !p.Liked),
                               My = findMyReaction(reactionsGroup),
                           }
                       };
            
            return Ok(new BaseResponse.SuccessResponse(null, data));
        }

        private bool? findMyReaction(IEnumerable<AnimeCommentReaction> reactions)
        {
            var reaction = reactions.SingleOrDefault(p => p.UserId == AuthUser?.Id);
            return reaction is null ? null : reaction.Liked;
        }

        [HttpPut("comments/{commentID}/text")]
        public async Task<IActionResult> ChangeAnimeCommentText(int commentID, [FromBody] string newText)
        {
            AnimeComment? comment = await DB.AnimeComments
                .Include(p => p.Anime)
                .Include(p => p.Writer)
                .SingleOrDefaultAsync(p => p.Id == commentID);

            if (comment == null)
            {
                return NotFound(new AnimeCommentResponse(false, "Invalid anime comment id!"));
            }

            if (AuthUser == null || AuthUser.Id != comment.WriterId)
            {
                return NotFound(new AnimeCommentResponse(false, "Invalid user!"));
            }

            comment.Comment = newText;

            DB.AnimeComments.Update(comment);

            await DB.SaveChangesAsync();

            return Ok(new AnimeCommentResponse(true, null, comment));
        }

        [HttpPut("comments/{commentID}/reaction")]
        public async Task<IActionResult> ChangeAnimeCommentReaction(int commentID, [FromBody] bool like)
        {
            AnimeComment? comment = await DB.AnimeComments
                .Include(p => p.Anime)
                .Include(p => p.Writer)
                .SingleOrDefaultAsync(p => p.Id == commentID);

            if (comment == null)
            {
                return NotFound(new AnimeCommentReactionResponse(false, "Invalid anime comment id!"));
            }

            AnimeCommentReaction? reaction = await DB.AnimeCommentReactions
                .SingleOrDefaultAsync(p => p.UserId == AuthUser.Id && p.CommentId == commentID);

            if (reaction == null)
            {
                User? user = await DB.Users.SingleOrDefaultAsync(p => p.Id == AuthUser.Id);

                reaction = (await DB.AddAsync(new AnimeCommentReaction
                {
                    UserId = AuthUser.Id,
                    CommentId = commentID,
                    Liked = like,
                    User = user,
                    Comment = comment
                })).Entity;

                return Ok(new AnimeCommentReactionResponse(true, null, reaction));
            }

            if (reaction.Liked == like)
            {
                reaction = DB.AnimeCommentReactions.Remove(reaction).Entity;
            }
            else
            {
                reaction.Liked = like;
                DB.AnimeCommentReactions.Update(reaction);
            }

            await DB.SaveChangesAsync();

            return Ok(new AnimeCommentReactionResponse(true, null, reaction));
        }

        [HttpDelete("comments/{commentID}")]
        public async Task<IActionResult> DeleteAnimeComment(int commentID)
        {
            AnimeComment? comment = await DB.AnimeComments
                .Include(p => p.Anime)
                .Include(p => p.Writer)
                .SingleOrDefaultAsync(p => p.Id == commentID);

            if (comment == null)
            {
                return NotFound(new AnimeCommentResponse(false, "Invalid anime comment id!"));
            }

            if (AuthUser == null || AuthUser.Id != comment.WriterId)
            {
                return NotFound(new AnimeCommentResponse(false, "Invalid user!"));
            }

            comment = DB.AnimeComments.Remove(comment).Entity;

            await DB.SaveChangesAsync();

            return Ok(new AnimeCommentResponse(true, null, comment));
        }

        // anime and user

        [HttpPost("anime-user")]
        public async Task<IActionResult> AddAnimeToUserList([FromBody] PostUserAnimeRequest request)
        {
            if (request.IsFavorite == false && request.State == Models.Enums.AnimeWatchingState.None)
            {
                return BadRequest(new UserAnimeResponse(false, "IsFavorite and State are invalid!"));
            }

            Anime? anime = await DB.Animes
                .Include(p => p.Genre)
                .Include(p => p.Format)
                .SingleOrDefaultAsync(p => p.Id == request.AnimeId);

            if (anime == null)
            {
                return BadRequest(new UserAnimeResponse(false, "Invalid anime ID!"));
            }

            User? user = await DB.Users.SingleOrDefaultAsync(p => p.Id == request.UserId);

            if (user == null)
            {
                return BadRequest(new UserAnimeResponse(false, "Invalid user ID!"));
            }

            UserAnime userAnime = (await DB.UserAnimes.AddAsync(new UserAnime
            {
                UserId = request.UserId,
                AnimeId = request.AnimeId,
                Rating = request.Rating,
                IsFavorite = request.IsFavorite,
                State = request.State,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Rewatches = request.Rewatches,
                EpisodesWatched = request.EpisodesWatched,
                Notes = request.Notes,
                Anime = anime,
                User = user
            })).Entity;

            await DB.SaveChangesAsync();

            return Ok(new UserAnimeResponse(true, null, userAnime));
        }

        [HttpGet("anime-user/by-user/{userID}")]
        public async Task<IActionResult> GetAnimesFromUserList(int userID)
        {
            List<UserAnime> list = await DB.UserAnimes
                .Include(p => p.Anime)
                .Where(p => p.UserId == userID)
                .OrderBy(p => p.Anime.Name)
                .ToListAsync();

            return Ok(new ListResponse<UserAnime>(true, null, list));
        }

        [HttpPut("anime-user/{userAnimeID}")]
        public async Task<IActionResult> UpdateAnimeInUserList(int userAnimeID, [FromBody] PutUserAnimeRequest request)
        {
            if (request.IsFavorite == false && request.State == Models.Enums.AnimeWatchingState.None)
            {
                return BadRequest(new UserAnimeResponse(false, "IsFavorite and State are invalid!"));
            }

            UserAnime? userAnime = await DB.UserAnimes
                .Include(p => p.Anime)
                .Include(p => p.User)
                .SingleOrDefaultAsync(p => p.Id == userAnimeID);

            if (userAnime == null)
            {
                return NotFound(new UserAnimeResponse(false, "Invalid user anime ID!"));
            }

            if ((userAnime.IsFavorite == false && request.State == Models.Enums.AnimeWatchingState.None) ||
                (request.IsFavorite == false && userAnime.State == Models.Enums.AnimeWatchingState.None))
            {
                userAnime = DB.UserAnimes.Remove(userAnime).Entity;
            }
            else
            {
                userAnime = (await DB.UserAnimes.AddAsync(new UserAnime
                {
                    UserId = userAnime.UserId,
                    AnimeId = userAnime.AnimeId,
                    Rating = request.Rating,
                    IsFavorite = request.IsFavorite,
                    State = request.State,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Rewatches = request.Rewatches,
                    EpisodesWatched = request.EpisodesWatched,
                    Notes = request.Notes,
                    Anime = userAnime.Anime,
                    User = userAnime.User
                })).Entity;
            }

            await DB.SaveChangesAsync();

            return Ok(new UserAnimeResponse(false, null, userAnime));
        }
    }
}
