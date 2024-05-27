using Application.Features.Customer.Commands.AddCustomer;
using Application.Features.Customer.Commands.UpdateCustomer;
using Application.Features.Customer.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Domain.Entities.Customer, CustomerDto>().ReverseMap();

            CreateMap<Domain.Entities.Customer, AddCustomerCommand>().ReverseMap().ForAllMembers(opt => opt.Condition((src,dest,val) => val is not null));

            CreateMap<Domain.Entities.Customer, UpdateCustomerCommand>().ReverseMap().ForAllMembers(opt => opt.Condition((src,dest,val) => val is not null));;
        }
    }
}
