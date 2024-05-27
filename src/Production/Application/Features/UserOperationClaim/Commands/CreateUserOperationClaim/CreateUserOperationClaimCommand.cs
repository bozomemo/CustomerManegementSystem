using Application.Features.UserOperationClaim.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommand : IRequest<UserOperationClaimDto>, ISecuredRequest
    {
        public int UserId { get; set; }

        public int OperationClaimId { get; set; }

        public string[] Roles => [OperationClaimConstants.Admin];
    }
}
