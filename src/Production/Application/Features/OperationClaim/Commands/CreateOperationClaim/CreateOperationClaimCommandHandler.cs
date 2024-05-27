using Application.Features.OperationClaimFeature.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Messages;
using MediatR;

namespace Application.Features.OperationClaimFeature.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, OperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var tempOperationClaim = await _operationClaimRepository.GetAsync(x => x.Name == request.Name);
            if (tempOperationClaim is not null) throw new BusinessException(ExceptionMessages.EntityExistsWithTheSame("İsim", "Yetki"));

            var operationClaim = _mapper.Map<Core.Security.Entities.OperationClaim>(request);

            var addedClaim = await _operationClaimRepository.AddAsync(operationClaim);

            return _mapper.Map<OperationClaimDto>(addedClaim);
        }
    }
}