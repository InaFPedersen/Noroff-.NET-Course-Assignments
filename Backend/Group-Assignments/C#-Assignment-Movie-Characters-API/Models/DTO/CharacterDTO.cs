
namespace MovieCharactersAPI.Models
{
    public class CharacterDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Alias { get; set; }
        [MaxLength(100)]
        public string Gender { get; set; }
        [MaxLength(100)]
        public string Picture { get; set; }
    }
}
