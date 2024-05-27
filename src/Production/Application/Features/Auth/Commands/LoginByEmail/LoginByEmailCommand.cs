using Application.Features.Auth.Dtos;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.LoginByEmail
{
    public class LoginByEmailCommand : IRequest<UserLoginDto>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string IpAddress { get; set; } = string.Empty;
    }
}
