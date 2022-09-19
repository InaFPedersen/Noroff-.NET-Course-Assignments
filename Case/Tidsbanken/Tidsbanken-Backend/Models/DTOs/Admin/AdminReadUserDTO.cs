#nullable disable

using System.ComponentModel.DataAnnotations;

namespace Tidsbanken_Backend.Models.DTOs.Admin
{
    public class AdminReadUserDTO
    {

        [Required, MaxLength(200)] public string Id { get; set; }
        [MaxLength(200)] public string ProfilePicture { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
        [Required, MaxLength(200)] public string Email { get; set; }
        [Required] public bool IsAdmin { get; set; }
        [Required] public int PhoneNumber { get; set; }
    }
}

#nullable enable