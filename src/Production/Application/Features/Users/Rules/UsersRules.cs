using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Validators;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public static class UsersRules
    {
        public static void IsUserValid(UserValidator validationRules, CreateUserCommand user){
            var validationResult = validationRules.Validate(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}
