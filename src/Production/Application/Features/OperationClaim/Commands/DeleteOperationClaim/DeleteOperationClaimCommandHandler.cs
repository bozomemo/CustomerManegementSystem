
using Application.Features.OperationClaimFeature.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Messages;
using MediatR;

namespace Application.Features.OperationClaim.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, OperationClaimDto>
    {
        public readonly IOperationClaimRepository _operationClaimRepository;
        public readonly IMapper _mapper;

        public DeleteOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Yetki"));

            var deletedOperationClaim = await _operationClaimRepository.DeleteAsync(operationClaim);

            return _mapper.Map<OperationClaimDto>(deletedOperationClaim);
        }
    }
}