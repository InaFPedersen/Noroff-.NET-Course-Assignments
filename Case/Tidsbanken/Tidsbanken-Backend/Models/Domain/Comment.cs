using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Tidsbanken_Backend.Models.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        [MaxLength(200)] public string Message { get; set; }



        [Required] public DateTime CreationDate { get; set; }
        public DateTime? LastTimeEdited { get; set; }
        /// <summary>
        /// This is the user which created the comment.
        /// </summary>
#nullable enable
        [MaxLength(200)] public string? AuthorId { get; set ; }
        public User? Author { get; set; }
        public int? VacationRequestId { get; set; }
        public VacationRequest? VacationRequest { get; set; }

    }

}