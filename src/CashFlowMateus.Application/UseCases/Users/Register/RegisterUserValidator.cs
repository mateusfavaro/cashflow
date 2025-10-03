﻿using CashFlowMateus.Communication.Requests;
using CashFlowMateus.Exception;
using FluentValidation;

namespace CashFlowMateus.Application.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {

        public RegisterUserValidator()
        {

            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
            RuleFor(user => user.Email).
                NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_EMPTY).
                EmailAddress().
                WithMessage(ResourceErrorMessages.EMAIL_INVALID);

            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
        }
    }
}