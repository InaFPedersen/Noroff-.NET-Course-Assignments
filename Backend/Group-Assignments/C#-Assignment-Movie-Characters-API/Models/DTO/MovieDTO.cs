

namespace MovieCharactersAPI.Models
{
    public class MovieDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Picture { get; set; }
        public string Trailer { get; set; }
    }
}
