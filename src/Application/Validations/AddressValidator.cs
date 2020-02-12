using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    
    {
        public AddressValidator()
        {

        }
    }
}
