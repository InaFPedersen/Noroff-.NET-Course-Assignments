using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Tidsbanken_Backend.Models.Domain
{
    public class VacationRequest
    {
        public int Id { get; set; }
        [MaxLength(100), Required] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        public VacationStatus VacationStatus { get; set; }
        public int VacationStatusId { get; set; }


        [Required, MaxLength(200)] public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }

}
#nullable enable