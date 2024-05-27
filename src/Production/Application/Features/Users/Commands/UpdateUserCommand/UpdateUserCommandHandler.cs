using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(ExceptionMessages.EntityDoesNotExist("Kullanıcı"));

            var tempUser = await _userRepository.GetAsync(x => x.Id != request.Id && x.Email == request.Email);
            if (tempUser != null) throw new BusinessException(ExceptionMessages.EntityExistsWithTheSame("Email", "Kullanıcı"));

            _mapper.Map(request, user);

            var dto = _mapper.Map<UserDto>(user);

            return dto;
        }
    }
}
