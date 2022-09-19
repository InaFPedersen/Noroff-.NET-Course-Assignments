using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Tidsbanken_Backend.Models.Domain
{
    public class IneligiblePeriod
    {
        public int Id { get; set; }
        [MaxLength(200)] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [MaxLength(200)] public string UserId { get; set; } 
        public User User { get; set; }
    }

}
#nullable enable