using Application.Features.Auth.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Domain.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.LoginByEmail
{
    public class LoginByEmailCommandHandler : IRequestHandler<LoginByEmailCommand, UserLoginDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginByEmailCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<UserLoginDto> Handle(LoginByEmailCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcı 
            var user = await _userRepository.GetAsync(x => x.Email == request.Email) ?? throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Kullanıcı"));

            // Kullanıcı parolaları eslesmeli
            if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) throw new BusinessException(ExceptionMessages.WRONG_PASSWORD);

            var accessToken = await _authService.CreateAccessToken(user);

            var refreshToken = _authService.CreateRefreshToken(user, request.IpAddress);

            var addedRefreshToken = await _authService.AddRefreshToken(refreshToken);

            return new() { AccessToken = accessToken, RefreshToken = addedRefreshToken };
        }
    }
}
