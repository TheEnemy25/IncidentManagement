using AutoMapper;
using IncidentManagement.Data.Entities;
using IncidentManagement.Domain.Dtos.Account;

namespace IncidentManagement.Domain.MappingProfiles
{
    internal sealed class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<CreateAccountDto, Account>();
            CreateMap<UpdateAccountDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}