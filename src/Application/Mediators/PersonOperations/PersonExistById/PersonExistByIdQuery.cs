using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.PersonExistById
{

    
    //Salida de persona por consulta de identificación
    public class PersonExistByIdQuery:IRequest<PersonExistVm>
    {
        public int Id { get; set; }
    }

    public class PersonExistByIdQueryHandler : IRequestHandler<PersonExistByIdQuery, PersonExistVm>
    {
        private readonly IPersonDbContext _context;
        public PersonExistByIdQueryHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<PersonExistVm> Handle(PersonExistByIdQuery request, CancellationToken cancellationToken)
        {
            var req = request.Id;
            var existValue = false;
            var exist = await _context.Person.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(exist != null)
            {
                existValue = true;
            }
            var vm = new PersonExistVm { exist = existValue };
            return vm;
        }
    }
}
