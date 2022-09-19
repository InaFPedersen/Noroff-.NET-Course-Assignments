
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MovieCharactersDbContext _context;

        public MovieController(MovieCharactersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Add a movie to the database.
        /// </summary>
        /// <param name="Movie"></param>
        /// <returns></returns>
        [HttpPost("Create/")]
        public async Task<IActionResult> Create([Bind("Title,Genre,ReleaseYear,Director,Picture,Trailer")] MovieDTO Movie)
        {

            var newMovie = _mapper.Map<Movie>(Movie);
            _context.Add(newMovie);
            await _context.SaveChangesAsync();


            return Ok(Movie);
        }

        /// <summary>
        /// Get a movie from the database, by ID.
        /// If there is no movie with this ID, the return will be null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Read/{id}")]
        public async Task<Movie?> ReadById(int id)
        {
            return await _context.Movies.FindAsync(id);
        }
        /// <summary>
        /// Get a collection of all movies.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ReadAll")]
        public IEnumerable<Movie> ReadAll()
        {
            return _context.Movies;
        }

        /// <summary>
        /// Update a movie of the given ID.
        /// If there is no movie with this ID, returns a NotFound result.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inputMovie"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [Bind("Title,Genre,ReleaseYear,Director,Picture,Trailer")] MovieDTO inputMovie)
        {
            var oldMovie = await _context.Movies.FindAsync(id);
            if (oldMovie == null)
            {
                return NotFound();
            }

            _context.Update(oldMovie);
            oldMovie.Title = inputMovie.Title;
            oldMovie.Genre = inputMovie.Genre;
            oldMovie.ReleaseYear = inputMovie.ReleaseYear;
            oldMovie.Director = inputMovie.Director;
            oldMovie.Picture = inputMovie.Picture;
            oldMovie.Trailer = inputMovie.Trailer;


            await _context.SaveChangesAsync();

            return Ok(oldMovie);
        }

        /// <summary>
        /// Delete a movie with the given ID. If there is no movie with this ID, returns a BadRequest result.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Movie = await _context.Movies.FindAsync(id);
            if (Movie == null)
            {
                return BadRequest();
            }
            _context.Movies.Remove(Movie);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Overwrite a movie with the given ID in the database. Foreign keys are preserved. 
        /// If there is no corresponding Id in the database, this return a BadRequest.
        /// </summary>
        /// <param name="movieId"></param>
        /// <param name="characterIds"></param>
        /// <returns></returns>
        [HttpPut("UpdateCharacters/{movieId}")]
        public async Task<IActionResult> UpdateCharacters(int movieId, [FromBody] List<int> characterIds)
        {
            var movie = await _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.Id == movieId)
                .FirstAsync();

            if (movie == null)
            {
                return BadRequest();
            }

            var Characters = new List<Character>();
            foreach (int characterId in characterIds)
            {
                Character? chara = await _context.Characters.FindAsync(characterId);
                if (chara == null)
                    return BadRequest($"Character if id {characterId} does not exist");
                Characters.Add(chara);

            }

            _context.Update(movie);
            movie.Characters = Characters;

            await _context.SaveChangesAsync();

            return Ok();
        }
        /// <summary>
        /// Get all characters associated with the movie of a given Id.
        /// If the movie does not exist, returns null.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        [HttpGet("ReadCharacters/{movieId}")]
        public async Task<List<Character>?> GetCharacters(int movieId)
        {
            var movie = await _context.Movies
                .Where(m => m.Id == movieId)
                .FirstAsync();

            if (movie == null)
                return null;

            return (from chara in _context.Characters
                    where chara.Movies.Contains(movie)
                    select chara).ToList();

        }
    }
}
