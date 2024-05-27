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

namespace Application.Features.UserOperationClaim.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, UserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public DeleteUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<UserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            var userOperationClaims = await _userOperationClaimRepository.Query().Include(x => x.OperationClaim).ToListAsync(cancellationToken);

            if (userOperationClaims.Count == 1 && userOperationClaims.First().OperationClaim.Name == "Admin") throw new BusinessException("Son admin kullanıcısının yetkisi silinemez!");

            var userOperationClaim = userOperationClaims.Where(x => x.Id == request.Id).FirstOrDefault() ?? 
                throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Yetki"));

            var deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(userOperationClaim);

            var dto = _mapper.Map<UserOperationClaimDto>(deletedUserOperationClaim);

            return dto;
        }
    }
}
