
using Application.Features.OperationClaimFeature.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Messages;
using MediatR;

namespace Application.Features.OperationClaim.Queries.GetOperationClaimById
{
    public class GetOperationClaimByIdQueryHandler : IRequestHandler<GetOperationClaimByIdQuery, OperationClaimDto>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetOperationClaimByIdQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
        {
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<OperationClaimDto> Handle(GetOperationClaimByIdQuery request, CancellationToken cancellationToken)
        {
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Yetki"));

            var operationClaimDto = _mapper.Map<OperationClaimDto>(operationClaim);

            return operationClaimDto;
        }
    }
}