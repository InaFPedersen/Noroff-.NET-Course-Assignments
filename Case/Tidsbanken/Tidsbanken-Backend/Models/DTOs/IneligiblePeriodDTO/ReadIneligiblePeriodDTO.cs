#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tidsbanken_Backend.Models.DTOs.IneligiblePeriodDTO
{
    public class ReadIneligiblePeriodDTO
    {
        [MaxLength(200)] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [MaxLength(200)] public string UserId { get; set; }

    }
}

#nullable enable