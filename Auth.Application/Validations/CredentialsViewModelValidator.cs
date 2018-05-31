﻿using Auth.Application.Models;
using FluentValidation;

namespace Auth.Application.Validations
{
    public class UserCredentialsValidator : AbstractValidator<UserCredentials>
    {
        public UserCredentialsValidator()
        {
            base.RuleFor(vm => vm.Login)
                .NotEmpty()
                .WithMessage("Username cannot be empty");

            base.RuleFor(vm => vm.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty");

            base.RuleFor(vm => vm.Password)
                .Length(6, 12)
                .WithMessage("Password must be between 6 and 12 characters");
        }        
    }
}
