using Application.Features.OperationClaimFeature.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Messages;
using MediatR;

namespace Application.Features.OperationClaim.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, OperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public UpdateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Yetki"));

            var tempOperationClaim = await _operationClaimRepository.GetAsync(x => x.Name == request.Name && x.Id != request.Id);
            if (tempOperationClaim is not null) throw new BusinessException(ExceptionMessages.EntityExistsWithTheSame("İsim", "Yetki"));

            _mapper.Map(request, operationClaim);

            var updatedOperationClaim = await _operationClaimRepository.UpdateAsync(operationClaim);

            return _mapper.Map<OperationClaimDto>(updatedOperationClaim);
        }
    }
}