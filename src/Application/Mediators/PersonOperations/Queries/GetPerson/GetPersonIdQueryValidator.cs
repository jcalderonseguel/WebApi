using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediators.PersonOperations.Queries
{
    public class GetPersonIdQueryValidator : AbstractValidator<GetPersonIdQuery>
    {
        private readonly IPersonDbContext _context;

        public GetPersonIdQueryValidator (IPersonDbContext context)
        {
            _context = context;

            RuleFor(x => x.PersonId).NotNull().MustAsync(async (personId, cancellation) =>
            {
                return await _context.Person.AnyAsync(x => x.Id == personId, cancellation);
            }).WithMessage(x => $"PersonId: {x.PersonId} does not exists.");
        }
    }
}
