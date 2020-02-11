using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Mediators.CountryOperations.InsertCountry
{
    public class InsertCountry : IRequest<long>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
    public class InsertHandler : IRequestHandler<InsertCountry, long>
    {
        private readonly IPersonDbContext _context;
        public InsertHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<long> Handle(InsertCountry request, CancellationToken cancellationToken)
        {
            Country country = new Country
            {
                Id = request.Id,
                Name = request.Name,
                IsoCode = request.IsoCode
            };
            _context.Country.Add(country);
            await _context.SaveChangesAsync(cancellationToken);

            return country.Id;
        }
    }
}
