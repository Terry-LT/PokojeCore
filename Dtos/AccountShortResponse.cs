using PokojeCore.Models.Enums;

namespace PokojeCore.Dtos
{
    public class AccountShortResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public AccountRole Role { get; set; }
    }
}
