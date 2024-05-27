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

namespace Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Müşteri"));

            // Update edilecek email ile baska bir entity varsa hata donuyoruz.
            var anotherCustomer = await _customerRepository.GetAsync(x => x.CustomerEmail == request.CustomerEmail && x.Id != request.Id);
            if (anotherCustomer is not null) throw new BusinessException(ExceptionMessages.EntityExistsWithTheSame("Email", "Müşteri"));

            _mapper.Map(request, customer);

            var updatedCustomer = await _customerRepository.UpdateAsync(customer);

            var dto = _mapper.Map<CustomerDto>(updatedCustomer);

            return dto;
        }
    }
}
