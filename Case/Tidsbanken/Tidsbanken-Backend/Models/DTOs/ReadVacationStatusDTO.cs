using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Tidsbanken_Backend.Models.DTOs
{
    public class ReadVacationStatusDTO
    {
        public int Id { get; set; }
        [MaxLength(20), Required] public string Status { get; set; }
        public string AdminId { get; set; }
        public DateTime ApprovalTime { get; set; }
    }
}
#nullable enable