using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

namespace Application.Mediators.CountryOperations
{
    public class GetCountryByIdQuery : IRequest<CountryVm>
    {
        public int CountryId { get; set; }
        public GetCountryByIdQuery(int CountryId)
        {
            this.CountryId = CountryId;
        }
    }
    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, CountryVm>
    {
        private readonly IPersonDbContext _context;

        public GetCountryByIdHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<CountryVm> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Country.Where(x => x.Id == request.CountryId).Select(x => new CountryDataDto
            {
                Id = x.Id,
                CountryName = x.Name

            }).ToListAsync();

            CountryVm vm = new CountryVm { CountryList = list };
            return vm;
        }
    }
}