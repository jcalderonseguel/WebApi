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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }

        public int GenderId { get; set; }

        public GetPersonByDocumentNumberQuery(string Name ,string LastName, string Rut, int GenderId)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Rut = Rut;
            this.GenderId = GenderId;

        }
    }
    public class GetPersonByDocumentNumberQueryHandler : IRequestHandler<GetPersonByDocumentNumberQuery,PersonInfoDto>
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
                Name=x.Name,
                LastName = x.LastName,
                Rut = x.Rut,
                GenderId = x.GenderId

            }).FirstOrDefaultAsync(cancellationToken);
            
            return p;
        }
       
    }
}
