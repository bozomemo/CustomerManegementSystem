using Application.Features.Customer.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            // Check if another user with same email exists.
            var tempCustomer = await _customerRepository.GetAsync(x => x.CustomerEmail == request.CustomerEmail);
            if (tempCustomer is not null) throw new BusinessException(ExceptionMessages.EntityExistsWithTheSame("Email", "Customer"));

            var customer = _mapper.Map<Domain.Entities.Customer>(request);

            var addedCustomer = await _customerRepository.AddAsync(customer);

            var addedCustomerDto = _mapper.Map<CustomerDto>(addedCustomer);

            return addedCustomerDto;
        }
    }
}
