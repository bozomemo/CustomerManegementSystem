using Application.Features.OperationClaimFeature.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;

namespace Application.Features.OperationClaimFeature.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<OperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => [OperationClaimConstants.Admin];
    }
}