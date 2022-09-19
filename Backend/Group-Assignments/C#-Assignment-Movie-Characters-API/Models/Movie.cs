# nullable disable
namespace MovieCharactersAPI.Models
{
    public class Movie
    {
        // Primary key
        public int Id { get; set; }

        // Properties
        [MaxLength(100), Required] public string Title { get; set; }
        [MaxLength(100)] public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(100)] public string Director { get; set; }
        [MaxLength(100)] public string Picture { get; set; }
        [MaxLength(100)] public string Trailer { get; set; }

        // Foreign keys
        public int FranchiseId { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
#nullable enable