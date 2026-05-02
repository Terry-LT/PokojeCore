using PokojeCore.Dtos;

namespace PokojeCore.Services
{
    public interface IAccountService
    {
        Task<List<AccountResponse>> GetAccountsAsync();
        Task<AccountResponse> GetAccountByIdAsync(int id);
        Task<AccountResponse> AddAccountAsync(AccountRequest request);
        Task<bool> UpdateAccountAsync(int id, AccountFirstLastNameRequest request);
        Task<bool> DeleteAccountAsync(int id);
    }
}
