using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Tidsbanken_Backend.Models.DTOs.Self
{
    public class SelfReadVacationRequestDTO
    {
        public int Id { get; set; }
        [MaxLength(100), Required] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [MaxLength(100)] public string Status { get; set; }
        public int VacationStatusId { get; set; }
        [Required, MaxLength(200)] public string UserId { get; set; }
    }
}

#nullable enable