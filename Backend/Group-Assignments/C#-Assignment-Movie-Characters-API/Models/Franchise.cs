#nullable disable
namespace MovieCharactersAPI.Models
{
    public class Franchise
    {
        // Primary key
        public int Id { get; set; }

        // Properties
        [MaxLength(100), Required] public string Name { get; set; }
        [MaxLength(100)] public string Description { get; set; }

        // Foreign keys
        public ICollection<Movie> Movies { get; set; }
    }
}
#nullable enable