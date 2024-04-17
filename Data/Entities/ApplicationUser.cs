using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace diplom_back.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(256)]
        public string? FirstName { get; set; } = null!;
        [MaxLength(256)]
        public string? NormalizedFirstName { get; set; } = null!;
        [MaxLength(256)]
        public string? LastName { get; set; } = null!;
        [MaxLength(256)]
        public string? NormalizedLastName { get; set; } = null!;
        [MaxLength(256)]
        public string? MiddleName { get; set; } = null!;
        [MaxLength(256)]
        public string? NormalizedMiddleName { get; set; } = null!;
    }
}
