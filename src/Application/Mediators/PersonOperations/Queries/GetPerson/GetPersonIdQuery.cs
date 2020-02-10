using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.Queries
{
    public class GetPersonIdQuery : IRequest<IdentificationPersonVm>
    {
        public int PersonId { get; set; }
        public GetPersonIdQuery(int PersonId)
        {
            this.PersonId = PersonId;
        }
    }
    public class GetPersonIdQueryHandler: IRequestHandler<GetPersonIdQuery, IdentificationPersonVm>
    {
        private readonly IPersonDbContext _context;
        public GetPersonIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<IdentificationPersonVm> Handle(GetPersonIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Person.Where(x => x.Id == request.PersonId).Select(x => new IdentificationPersonDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Rut = x.Rut,
                GenderId = x.GenderId,

            }).ToListAsync();
            IdentificationPersonVm Vm = new IdentificationPersonVm { idPersonList = list };
            return Vm;
        }
    }
}
