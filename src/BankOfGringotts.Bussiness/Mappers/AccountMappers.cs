using AutoMapper;
using BankOfGringotts.Contracts.Responses.Account;
using BankOfGringotts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfGringotts.Bussiness.Mappers
{
    public class AccountMappers : Profile
    {
        public AccountMappers()
        {
            CreateMap<Accounts, AccountResponse>()
                .ForMember(dest => dest.AccountNo, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LastActivityDate, opt => opt.MapFrom(src => src.LastActivityDate))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<Accounts, AccountAbstract>()
                .ForMember(dest => dest.AccountNo, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));
           
        }
    }
}
