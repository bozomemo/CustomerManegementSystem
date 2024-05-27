using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UserDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string[] Roles => [OperationClaimConstants.User, OperationClaimConstants.Admin];
    }
}
