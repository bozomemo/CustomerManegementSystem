using Application.Features.UserOperationClaim.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Queries.GetAllUserOperationClaims
{
    public class GetAllUserOperationClaimsCommand : IRequest<ICollection<UserOperationClaimDto>>, ISecuredRequest
    {
        public string[] Roles => [OperationClaimConstants.Admin, OperationClaimConstants.User];
    }
}
