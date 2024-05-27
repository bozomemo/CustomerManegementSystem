using Application.Features.Customer.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, ICollection<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<ICollection<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.Query().ToListAsync(cancellationToken);

            var dtos = _mapper.Map<List<CustomerDto>>(customers);

            return dtos;
        }
    }
}
