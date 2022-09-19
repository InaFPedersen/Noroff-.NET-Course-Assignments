
namespace MovieCharactersAPI.Models
{
    public class FranchiseDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
