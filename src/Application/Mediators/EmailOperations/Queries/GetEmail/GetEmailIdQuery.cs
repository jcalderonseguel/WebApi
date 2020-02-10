using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.EmailOperations.Queries
{
    //Hereda de
    public class GetEmailIdQuery : IRequest<IdentificationEmailVm>
    {
        public int EmailId { get; set; }
        public GetEmailIdQuery(int EmailId)
        {
            this.EmailId = EmailId;
        }
    }
    public class GetEmailIdQueryHandler: IRequestHandler<GetEmailIdQuery, IdentificationEmailVm>
    {
        private readonly IPersonDbContext _context;
        public GetEmailIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<IdentificationEmailVm> Handle(GetEmailIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Email.Where(x => x.Id == request.EmailId).Select(x => new IdentificationEmailDto 
            { 
                Id = x.Id,
                Description = x.Description,
                PersonId = x.PersonId,

            }).ToListAsync();

            IdentificationEmailVm Vm = new IdentificationEmailVm { idEmailList = list };
            return Vm;
        }
    }
}
