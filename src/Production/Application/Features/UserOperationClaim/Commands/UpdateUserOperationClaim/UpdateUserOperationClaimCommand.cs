using Application.Features.UserOperationClaim.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand : IRequest<UserOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => [OperationClaimConstants.Admin];
    }
}
