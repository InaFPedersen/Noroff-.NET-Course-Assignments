using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Tidsbanken_Backend.Models.DTOs.CommentDTO
{
    public class UpdateCommentDTO
    {
        public int Id { get; set; }

        [MaxLength(200)] public string Message { get; set; }

    }
}
#nullable enable