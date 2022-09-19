using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI
{
    public class MovieCharactersDbContext : DbContext
    {
        // This constructor appears unused but is needed by the framework.
        public MovieCharactersDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Movie movie1 = new() { Id = 1, FranchiseId = 1, Director = "Pete", Genre = "Thriller", ReleaseYear = 1972, Picture = "google.images.com", Title = "The Movie", Trailer = "youtube.com" };
            Movie movie2 = new() { Id = 2, FranchiseId = 1, Director = "Pete", Genre = "Thriller", ReleaseYear = 1973, Picture = "google.images.com", Title = "The Movie 2", Trailer = "youtube.com" };
            Movie movie3 = new() { Id = 3, FranchiseId = 1, Director = "Pete", Genre = "Thriller", ReleaseYear = 1974, Picture = "google.images.com", Title = "The Movie: The Prequel", Trailer = "youtube.com" };
            modelBuilder.Entity<Movie>().HasData(movie1, movie2, movie3);

            Character Character1 = new Character() { Id = 1, Name = "Hans", Alias = "the guy", Gender = "male", Picture = "imgur" };
            Character Character2 = new Character() { Id = 2, Name = "apeoivfk", Alias = "thpovpa", Gender = "female", Picture = "imgur" };
            Character Character3 = new Character() { Id = 3, Name = "kjnbw", Alias = "taorgi", Gender = "male", Picture = "imgur" };

            Franchise Franchise = new() { Id = 1, Description = "A franchise of movies", Name = "The Franchise" };
        }
    }
}
