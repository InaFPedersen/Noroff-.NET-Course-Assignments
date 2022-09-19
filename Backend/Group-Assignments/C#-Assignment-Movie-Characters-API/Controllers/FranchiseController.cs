
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FranchiseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MovieCharactersDbContext _context;

        public FranchiseController(MovieCharactersDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }


        /// <summary>
        /// Create a new Franchise
        /// </summary>
        /// <param name="Franchise"></param>
        /// <returns></returns>
        [HttpPost("Create/")]
        public async Task<IActionResult> Create([Bind("Name,Description")] FranchiseDTO Franchise)
        {

            var newFranchise = _mapper.Map<Franchise>(Franchise);
            _context.Add(newFranchise);
            await _context.SaveChangesAsync();


            return Ok(Franchise);
        }

        /// <summary>
        /// Get Franchise through id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Read/{id}")]
        public async Task<Franchise?> ReadById(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        /// <summary>
        /// Get all Franchise in database
        /// </summary>
        /// <returns></returns>
        [HttpGet("ReadAll")]
        public IEnumerable<Franchise> ReadAll()
        {
            return _context.Franchises;
        }


        /// <summary>
        /// Update Franchise by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inputFranchise"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [Bind("Name,Description")] FranchiseDTO inputFranchise)
        {
            var oldFranchise = await _context.Franchises.FindAsync(id);
            if (oldFranchise == null)
            {
                return NotFound();
            }

            _context.Update(oldFranchise);
            oldFranchise.Name = inputFranchise.Name;
            oldFranchise.Description = inputFranchise.Description;


            await _context.SaveChangesAsync();

            return Ok(oldFranchise);
        }


        /// <summary>
        /// Delete Franchise by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Franchise = await _context.Franchises.FindAsync(id);
            if (Franchise == null)
            {
                return BadRequest();
            }
            _context.Franchises.Remove(Franchise);
            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Update movies listen in Franchise by id
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <param name="movieIds"></param>
        /// <returns></returns>
        [HttpPut("UpdateMovies/{franchiseId}")]
        public async Task<IActionResult> UpdateMovies(int franchiseId, int[] movieIds)
        {
            var Franchise = await _context.Franchises.FindAsync(franchiseId);
            if (Franchise == null)
            {
                return BadRequest();
            }

            var Movies = _context.Movies.Where(m => movieIds.Contains(m.Id));

            foreach (var movie in Movies)
            {
                _context.Update(movie);
                movie.FranchiseId = franchiseId;

            }

            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Get list of movies from Franchise selected by id
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        [HttpGet("ReadMovies/{franchiseId}")]
        public async Task<List<Movie>?> GetMovies(int franchiseId)
        {
            var franchise = await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .FirstAsync();

            if (franchise == null)
                return null;

            return (from movie in _context.Movies
                    where movie.FranchiseId == franchiseId
                    select movie).ToList();

        }

        /// <summary>
        /// Get list of characters in selected Franchise
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        [HttpGet("ReadCharacters/{franchiseId}")]
        public async Task<List<Character>?> GetCharacters(int franchiseId)
        {
            var franchise = await _context.Franchises
                .Where(f => f.Id == franchiseId)
                .FirstAsync();

            if (franchise == null)
                return null;

            var movies = _context.Movies
                .Include(m => m.Characters)
                .Where(m => m.FranchiseId == franchiseId);

            return movies.SelectMany(m => m.Characters).Distinct().ToList();
        }
    }
}
