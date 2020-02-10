using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediators.EmailOperations.Queries
{
    public class GetEmailIdQueryValidator : AbstractValidator<GetEmailIdQuery>
    {
        private readonly IPersonDbContext _context;

        public GetEmailIdQueryValidator(IPersonDbContext context)
        {
            _context = context;

            RuleFor(x => x.EmailId).NotNull().MustAsync(async (emailId, cancellation) =>
            {
                return await _context.Email.AnyAsync(x => x.Id == emailId, cancellation);
            }).WithMessage(x => $"EmailId: {x.EmailId} does not exists.");
        }
    }
}
