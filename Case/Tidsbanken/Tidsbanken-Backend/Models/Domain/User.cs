using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable
namespace Tidsbanken_Backend.Models.Domain
{
    public class User
    {
        [Required, MaxLength(200)] public string Id { get; set; }
        [MaxLength(200)] public string ProfilePicture { get; set; }
        [Required, MaxLength(200)] public string FirstName { get; set; }
        [Required, MaxLength(200)] public string LastName { get; set; }
        [Required, MaxLength(200)] public string Email { get; set; }
        [Required] public bool IsAdmin { get; set; }
        [Required] public int PhoneNumber { get; set; }

        public ICollection<VacationRequest> VacationRequests { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<IneligiblePeriod> IneligiblePeriods { get; set; }
    }

}
#nullable enable