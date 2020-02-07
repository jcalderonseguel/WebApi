using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.GetPersonByDocumentNumber
{
    public class GetPersonByDocumentNumberQuery : IRequest<PersonInfoDto>
    {


        public int Id { get; set; }

        public GetPersonByDocumentNumberQuery(int Id)
        {

            this.Id = Id;

        }
    }
    public class GetPersonByDocumentNumberQueryHandler : IRequestHandler<GetPersonByDocumentNumberQuery, PersonInfoDto>
    {
        private readonly IPersonDbContext _context;
        public GetPersonByDocumentNumberQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }

        public async Task<PersonInfoDto> Handle(GetPersonByDocumentNumberQuery request, CancellationToken cancellationToken)
        {
            var p = await _context.Person.Select(x => new PersonInfoDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Rut = x.Rut,
                GenderId = x.GenderId

            }).Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            return p;
        }

    }
}