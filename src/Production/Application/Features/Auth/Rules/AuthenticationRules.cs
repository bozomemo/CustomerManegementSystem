using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthenticationRules
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    }
}
