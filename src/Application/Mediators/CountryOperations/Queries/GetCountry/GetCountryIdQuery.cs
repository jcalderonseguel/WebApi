using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.IdCountryOperations.Queries
{
    public class GetCountryIdQuery : IRequest<IdentificationCountryVm>
    {
        public int CountryId { get; set; }
        public GetCountryIdQuery(int CountryId)
        {
            this.CountryId = CountryId;
        }

    }
    public class GetCountryIdQueryHandler: IRequestHandler<GetCountryIdQuery, IdentificationCountryVm>
    {
        private readonly IPersonDbContext _context;

        public GetCountryIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<IdentificationCountryVm> Handle(GetCountryIdQuery request, CancellationToken cancellationToken)
        {

            //Se colocara (donde esta country), la tabla deseada para definir los parametros a mostrar.
            var list = await _context.Country.Where(x => x.Id == request.CountryId).Select(x => new IdentificationCountryDto
            {
                Id = x.Id,
                Name = x.Name,
                IsoCode = x.IsoCode,
            }).ToListAsync();

            IdentificationCountryVm vm = new IdentificationCountryVm { idCountryList = list };
            return vm;
        }
    }
}
