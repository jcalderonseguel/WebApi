using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Mediators.GenderOperations.Queries
{
    public class GetGenderByIdQuery : IRequest<IdentificationGenderVm>
    {
        public int GenderId { get; set; }
        public GetGenderByIdQuery(int GenderId)
        {
            this.GenderId = GenderId;
        }
    }

    public class GetGenderByIdQueryHandler : IRequestHandler<GetGenderByIdQuery, IdentificationGenderVm>
    {
        private readonly IPersonDbContext _context;

        public GetGenderByIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }

        public async Task<IdentificationGenderVm> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Gender.Where(x => x.Id == request.GenderId).Select(x => new IdentificationGenderDto
            {
                Id = x.Id,
                Description = x.Description
            }).ToListAsync();

            IdentificationGenderVm vm = new IdentificationGenderVm { idGenderList = list };
            return vm;
        }
    }
}
