using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Tidsbanken_Backend.Models.DTOs.Self
{
    public class SelfCreateVacationRequestDTO
    {
        [MaxLength(100), Required] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [MaxLength(200)] public string UserId { get; set; }
    }
}

#nullable enable