using Application.Features.Users.Dtos;
using Core.Application.Pipelines.Authorization;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<ICollection<UserDto>>, ISecuredRequest
    {
        public string[] Roles => [OperationClaimConstants.Admin, OperationClaimConstants.User];
    }
}
