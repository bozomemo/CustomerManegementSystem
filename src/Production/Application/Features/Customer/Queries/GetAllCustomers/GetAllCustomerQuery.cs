using Application.Features.Customer.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomerQuery : IRequest<ICollection<CustomerDto>>, ISecuredRequest
    {
        public string[] Roles => [OperationClaimConstants.Admin, OperationClaimConstants.User];
    }
}
