using Application.Features.UserOperationClaim.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Messages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.Queries.GetUserOperationClaim
{
    public class GetUserOperationClaimByIdCommandHandler : IRequestHandler<GetUserOperationClaimByIdCommand, UserOperationClaimDto>
    {
        public readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public readonly IMapper _mapper;

        public GetUserOperationClaimByIdCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<UserOperationClaimDto> Handle(GetUserOperationClaimByIdCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaim = await _userOperationClaimRepository.Query().Where(x => x.Id == request.Id)
                .Include(x => x.User).Include(x => x.OperationClaim).FirstOrDefaultAsync() ?? 
                throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Kullanıcı Yetkisi"));

            var userOperationClaimDto = _mapper.Map<UserOperationClaimDto>(userOperationClaim);

            return userOperationClaimDto;
        }
    }
}