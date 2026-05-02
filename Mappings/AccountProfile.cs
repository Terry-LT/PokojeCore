using AutoMapper;
using PokojeCore.Dtos;
using PokojeCore.Models;

namespace PokojeCore.Mappings
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountResponse>();
            //Requests
            CreateMap<AccountRequest, Account>();
            CreateMap<AccountFirstLastNameRequest, Account>();
        }
    }
}
