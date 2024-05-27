using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;

namespace Application.Features.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<UserDto>, ISecuredRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public string[] Roles => [OperationClaimConstants.Admin];
    }
}
