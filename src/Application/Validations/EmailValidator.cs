using Application.Common.Helpers;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validations
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Description).NotNull().Must((email) =>
            {
                return (email.Trim().Equals("")) ? true : CommonHelper.EmailFormat(email);

            }).WithMessage("Email format incorrect");
        }
    }
}
