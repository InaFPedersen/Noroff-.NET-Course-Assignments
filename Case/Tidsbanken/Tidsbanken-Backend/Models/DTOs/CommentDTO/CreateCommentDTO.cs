using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Tidsbanken_Backend.Models.DTOs.CommentDTO
{
    public class CreateCommentDTO
    {
        [MaxLength(200)] public string Message { get; set; }

        [MaxLength(200)] public string AuthorId { get; set; }
        public int VacationRequestId { get; set; }
    }
}
#nullable enable