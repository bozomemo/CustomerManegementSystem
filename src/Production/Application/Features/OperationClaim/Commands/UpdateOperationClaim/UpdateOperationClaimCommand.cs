
using Application.Features.OperationClaimFeature.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<OperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string[] Roles => [OperationClaimConstants.Admin];
    }
}