using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokojeCore.Data;
using PokojeCore.Dtos;
using PokojeCore.Models;

namespace PokojeCore.Services
{
    //In future only manager/admin can have acess to methods(except login)
    public class AccountService(AppDbContext context, IMapper mapper) : IAccountService
    {
        public async Task<AccountResponse> AddAccountAsync(AccountRequest request)
        {
            if (await context.Accounts.AnyAsync(a => a.Email == request.Email))
            {
                throw new InvalidOperationException("Email already exists");
            }

            var newAccount = new Account
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email.Trim(),
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            var hasher = new PasswordHasher<Account>();
            newAccount.PasswordHash = hasher.HashPassword(newAccount, request.Password);

            context.Accounts.Add(newAccount);
            await context.SaveChangesAsync();

            return mapper.Map<AccountResponse>(newAccount);

        }

        public async Task<bool> DeleteAccountAsync(int id)
        {
            var accountToDelete = await context.Accounts.FindAsync(id);
            if (accountToDelete == null)
            {
                return false;
            }
            context.Accounts.Remove(accountToDelete);
            await context.SaveChangesAsync();
            return true;
           
        }

        public async Task<AccountResponse> GetAccountByIdAsync(int id)
        {
            var account = await context.Accounts.Where(a => a.Id == id)
                .ProjectTo<AccountResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            return account;
        }

        public async Task<List<AccountResponse>> GetAccountsAsync()
        => await context.Accounts.AsNoTracking()
            .ProjectTo<AccountResponse>(mapper.ConfigurationProvider)
            .ToListAsync();
        
        public async Task<bool> UpdateAccountAsync(int id, AccountFirstLastNameRequest request)
        {
            var accountToUpdate = await context.Accounts.FindAsync(id);
            if (accountToUpdate == null)
            {
                return false;
            }
            accountToUpdate.FirstName = request.FirstName;
            accountToUpdate.LastName = request.LastName;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
