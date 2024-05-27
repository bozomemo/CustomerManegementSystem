
using Application.Features.OperationClaimFeature.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<OperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => [OperationClaimConstants.Admin];
    }
}
