using PokojeCore.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PokojeCore.Dtos
{
    public class AccountFirstLastNameRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
