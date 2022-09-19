using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Tidsbanken_Backend.Models.DTOs.Admin
{
    public class AdminReadVacationRequestDTO
    {
        public int Id { get; set; }
        [MaxLength(100), Required] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        public int VacationStatusId { get; set; }
        public string UserId { get; set; }
    }
}

#nullable enable