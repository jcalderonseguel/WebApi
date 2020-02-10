using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.IdCountryOperations.Queries
{
    public class GetCountryIdQueryValidator : AbstractValidator<GetCountryIdQuery>
    {
        private readonly IPersonDbContext _context;

        public GetCountryIdQueryValidator(IPersonDbContext context)
        {
            _context = context;

            RuleFor(x => x.CountryId).NotNull().MustAsync(async (countryId, cancellation) =>
            {

                return await _context.Country.AnyAsync(x => x.Id == countryId, cancellation);
            }).WithMessage(x => $"CountryId: {x.CountryId} does not exists.");
        }
    }
}
