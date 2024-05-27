using Application.Features.Customer.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<CustomerDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => [OperationClaimConstants.Admin];
    }
}
