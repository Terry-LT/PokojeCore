using PokojeCore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PokojeCore.Dtos
{
    public class AccountRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public AccountRole Role { get; set; } = AccountRole.Receptionist;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
