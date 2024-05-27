using Application.Features.Users.Commands.CreateUserCommand;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Validators
{
    public class UserValidator : AbstractValidator<CreateUserCommand>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(20).WithMessage("First name cannot exceed 20 characters!");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(20).WithMessage("Last name cannot exceed 20 characters!");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email address is invalid!");
            RuleFor(user => user.Password).MinimumLength(4).WithMessage("Password must be 4 characters or longer!")
                .MaximumLength(20).WithMessage("Password cannot exceed 20 characters!");
        }
    }
}
