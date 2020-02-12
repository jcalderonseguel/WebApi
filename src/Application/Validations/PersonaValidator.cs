using Application.Common.Interfaces;
using Application.Mediators.Insert;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class PersonValidator : AbstractValidator<InsertPerson>
    {
        private readonly IPersonDbContext _context;

        public PersonValidator(IPersonDbContext context)
        {
            _context = context;


            RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("no empty")
                
                .MustAsync(async(Id, CancellationToken) =>
            {
                return await _context.Person.AnyAsync(x => x.Id == Id, CancellationToken);

            }).When(x => x.Id != 0).WithMessage(x => $"Person Id:{x.Id} does not exits.");

            RuleFor(X => X.Address).NotEmpty().WithMessage("Address is must not be empty ");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is must not be empty");

            RuleForEach(x => x.Address).NotNull().SetValidator(new AddressValidator());

            RuleForEach(x => x.Email).NotNull().SetValidator(new EmailValidator());
        }

     
    