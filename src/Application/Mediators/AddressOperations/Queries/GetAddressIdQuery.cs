using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.AddressOperations.Queries
{
    //GetAddressIdQuery hereda de IRequest<IdentificationAddressVm>
    public class GetAddressIdQuery : IRequest<IdentificationAddressVm>
    {
        public int AddressId { get; set; }
        public GetAddressIdQuery(int AddressId)
        {
            this.AddressId = AddressId;
        }
    }
    public class GetAddressIdQueryHandler: IRequestHandler<GetAddressIdQuery, IdentificationAddressVm>
    {
        private readonly IPersonDbContext _context;
        public GetAddressIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }

        public async Task<IdentificationAddressVm> Handle(GetAddressIdQuery request, CancellationToken cancellationToken)
        {
            //Se colocara (donde esta Address), la tabla deseada para definir los parametros a mostrar.
            var list = await _context.Address.Where(x => x.Id == request.AddressId).Select(x => new IdentificationAddressDto
            {
                Id = x.Id,
                StreetName = x.StreetName,
                Number = x.Number,
                PostCode = x.PostCode,
                PersonId = x.PersonId,
                CountryId = x.CountryId,

            }).ToListAsync();

            IdentificationAddressVm Vm = new IdentificationAddressVm { idAddressList = list };
            return Vm;
        }
    }
}
