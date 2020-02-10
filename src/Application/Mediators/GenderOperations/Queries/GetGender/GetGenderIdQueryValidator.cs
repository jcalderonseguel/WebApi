using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.GenderOperations.Queries
{
    public class GetGenderIdQueryValidator : AbstractValidator<GetGenderIdQuery>
    {
        private readonly IPersonDbContext _context;

        public GetGenderIdQueryValidator(IPersonDbContext context)
        {
            _context = context;

            RuleFor(x => x.GenderId).NotNull().MustAsync(async (genderId, cancellation) =>
            {

                return await _context.Gender.AnyAsync(x => x.Id == genderId, cancellation);
            }).WithMessage(x => $"GenderId: {x.GenderId} does not exists.");
        }
    }
}
