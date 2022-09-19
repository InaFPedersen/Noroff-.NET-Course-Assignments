#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tidsbanken_Backend.Models.DTOs.Self
{
    public class SelfUpdateUserDTO
    {
        [Required, MaxLength(200)] public string Id { get; set; }
        [MaxLength(200)] public string ProfilePicture { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
        [Required, MaxLength(200)] public string Email { get; set; }
    }
}

#nullable enable