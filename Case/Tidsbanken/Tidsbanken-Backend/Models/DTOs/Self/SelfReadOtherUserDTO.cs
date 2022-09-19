#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tidsbanken_Backend.Models.DTOs.Self
{
    public class SelfReadOtherUserDTO
    {
        [MaxLength(200)] public string ProfilePicture { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
    }
}

#nullable enable