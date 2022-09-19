using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Tidsbanken_Backend.Models.DTOs.Self
{
    public class SelfUpdateVacationRequestDTO
    {
        public int Id { get; set; }
        [MaxLength(100), Required] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
    }
}

#nullable enable