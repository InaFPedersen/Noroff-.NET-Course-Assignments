#nullable disable
namespace MovieCharactersAPI.Models
{
    public class Character
    {
        // Primary key
        public int Id { get; set; }

        // Properties
        [MaxLength(100), Required] public string Name { get; set; }
        [MaxLength(100)] public string Alias { get; set; }
        [MaxLength(100)] public string Gender { get; set; }
        [MaxLength(100)] public string Picture { get; set; }

        // Foreign key
        public ICollection<Movie> Movies { get; set; }
    }
}
#nullable enable