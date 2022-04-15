using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BankOfGringotts.Contracts.Requests.Customer;
using BankOfGringotts.Contracts.Responses.Customer;
using BankOfGringotts.Model;

namespace BankOfGringotts.Bussiness.Mappers
{
    public class CustomerMappers : Profile
    {
        public CustomerMappers()
        {
            CreateMap<Customers, CustomerResponse>()
                .ForMember(dest => dest.CustomerNo, opt => opt.MapFrom(src => src.Id));

            
            CreateMap<PostCustomerRequest, Customers>();
        }
    }
}
