using Microsoft.EntityFrameworkCore;
using PokojeCore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PokojeCore.Models
{
    [Index(nameof(Email), IsUnique = true)]

    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required,EmailAddress]
        public string Email { get; set; } = string.Empty;
        public AccountRole Role { get; set; } = AccountRole.Receptionist;
        [Required]
        public string PasswordHash {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
