
using Application.Features.OperationClaimFeature.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.Queries.GetAllOperationClaims
{
    public class GetAllOperationClaimQuery : IRequest<ICollection<OperationClaimDto>>, ISecuredRequest
    {
        public string[] Roles => [OperationClaimConstants.Admin, OperationClaimConstants.User];
    }
}
