using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace Application.Mediators.AddressOperations.Queries
{
    //GetAddressIdQueryValidator hereda de : GetCountryIdQuery
    public class GetAddressIdQueryValidator : AbstractValidator<GetAddressIdQuery>
    {
        private readonly IPersonDbContext _context;

        public GetAddressIdQueryValidator(IPersonDbContext context)
        {
            _context = context;

            RuleFor(x => x.AddressId).NotNull().MustAsync(async (addressId, cancellation) =>
            {
                return await _context.Address.AnyAsync(x => x.Id == addressId, cancellation);
            }).WithMessage(x => $"AddressId: {x.AddressId} does not exists.");
        }
    }
}
