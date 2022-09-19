#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tidsbanken_Backend.Models.DTOs.IneligiblePeriodDTO
{
    public class CreateIneligiblePeriodDTO
    {
        [MaxLength(200)] public string Title { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
    }
}

#nullable enable