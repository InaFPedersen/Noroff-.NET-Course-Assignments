#nullable disable
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharactersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MovieCharactersDbContext _context;

        public CharactersController(MovieCharactersDbContext context, IMapper mapper)
        {
            _context = context;

            _mapper = mapper;
        }


        /// <summary>
        /// Add a new character to the database. 
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        [HttpPost("Create/")]
        public async Task<IActionResult> Create([Bind("Name,Alias,Gender,Picture")] CharacterDTO character)
        {

            var newCharacter = _mapper.Map<Character>(character);
            _context.Add(newCharacter);
            await _context.SaveChangesAsync();


            return Ok(character);
        }

        /// <summary>
        /// Get a character with a given ID from the database.
        /// If there is no movie with this ID, the return will be null.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Read/{id}")]
        public async Task<CharacterDTO> ReadById(int id)
        {
            var result = await _context.Characters.FindAsync(id);
            return _mapper.Map<CharacterDTO>(result);
        }
        /// <summary>
        /// Get all characters from the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ReadAll")]
        public IEnumerable<Character> ReadAll()
        {
            return  _context.Characters;
        }


        /// <summary>
        /// Update a character of the given ID.
        /// If there is no character with this ID, returns a NotFound result.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inputCharacter"></param>
        /// <returns></returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateById(int id, [Bind("Name,Alias,Gender,Picture")] CharacterDTO inputCharacter)
        {
            var oldCharacter = await _context.Characters.FindAsync(id);
            if (oldCharacter == null)
            {
                return NotFound();
            }

            _context.Update(oldCharacter);
            oldCharacter.Name = inputCharacter.Name;
            oldCharacter.Alias = inputCharacter.Alias;
            oldCharacter.Picture = inputCharacter.Picture;
            oldCharacter.Gender = inputCharacter.Gender;

            await _context.SaveChangesAsync();

            return Ok(oldCharacter);
        }
        

        /// <summary>
        /// Delete the character of the given Id.
        /// Returns a BadRequest if the character does not exist.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return BadRequest();
            }
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return Ok();
        }

        
    }
}

