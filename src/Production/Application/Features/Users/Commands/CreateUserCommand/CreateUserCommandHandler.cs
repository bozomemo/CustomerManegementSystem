using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Features.Users.Validators;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;
using Domain.Messages;
using MediatR;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserValidator _userValidator;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, UserValidator userValidator, IMapper mapper, IOperationClaimRepository operationClaimRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _mapper = mapper;
            _operationClaimRepository = operationClaimRepository;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UsersRules.IsUserValid(_userValidator,request);

            byte[] hash, salt;

            HashingHelper.CreatePasswordHash(request.Password, out hash, out salt);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = hash,
                PasswordSalt = salt,
            };

            var createdUser = await _userRepository.AddAsync(user);

            // Default olarak eğer kullanıcıya user yetkisi veriyorum.
            var operationClaim = await _operationClaimRepository.GetAsync(x => x.Name == "user") ?? throw new BusinessException("Varsayılan olarak kullanılar kullanıcı yetkisi bulunumadı! Lütfen user adlı bir yetki oluşturun!");
            await _userOperationClaimRepository.AddAsync(new Core.Security.Entities.UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = createdUser.Id });


            var userDto = _mapper.Map<UserDto>(createdUser);

            return userDto;

        }
    }
}
