using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankOfGringotts.Contracts.Responses.AccountTransaction;
using BankOfGringotts.Model;

namespace BankOfGringotts.Bussiness.Mappers
{
    public class AccountTransactionMappers : Profile
    {
        public AccountTransactionMappers()
        {
            CreateMap<AccountTransactions, AccountTransactionResponse>()
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.AccountNo, opt => opt.MapFrom(src => src.AccountId));

            CreateMap<AccountTransactions, AccountTransactionAbstractResponse>()
                .ForMember(dest => dest.TransactionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TransactionDate, opt => opt.MapFrom(src => src.CreatedDate));

        }
    }
}
