using System.ComponentModel.DataAnnotations;
#nullable disable
namespace Tidsbanken_Backend.Models.DTOs.Admin
{
    public class AdminUpdateVacationStatusDTO
    {
        public int Id { get; set; }
        [MaxLength(20), Required] public string Status { get; set; }

        [MaxLength(200)] public string AdminId { get; set; }
        public DateTime ApprovalTime { get; set; }
    }
}
#nullable enable