using System;
using System.Collections.Generic;
using MediatR;
using Application.Common.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entities;

namespace Application.Mediators.PersonOperations.Queries
{
    public class InsertPerson: IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public int GenderId { get; set; }
    }

    public class InsertHandler : IRequestHandler<InsertPerson, int>
    {
        private readonly IPersonDbContext _context;

        public InsertHandler(IPersonDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(InsertPerson request, CancellationToken cancellationToken)
        {
            Person person = new Person
            {
                Id = request.Id,
                Name = request.Name,
                LastName = request.LastName,
                Rut = request.Rut,
                GenderId = request.GenderId
            };
            _context.Person.Add(person);
            await _context.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}
