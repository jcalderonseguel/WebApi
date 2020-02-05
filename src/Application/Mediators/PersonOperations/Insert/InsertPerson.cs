using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.Insert
{
    public class InsertPerson : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Email> Email { get; set; }
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
            List<Address> addresses = new List<Address>();
            if(!request.Address.Equals(null))
            {
                foreach(var a in request.Address)
                {
                    var address = new Address
                    {
                        StreetName = a.StreetName,
                        Number = a.Number,
                        PostCode = a.PostCode,

                    };
                    addresses.Add(address);
                }

            }
            List<Email> emails = new List<Email>();
            if(!request.Email.Equals(null))
            {
                foreach(var e in request.Email)
                {
                    var email = new Email
                    {
                        Description = e.Description,
                    };
                    emails.Add(email);
                }
            }

            Person person = new Person
            {
               
                Name = request.Name,
                LastName = request.Rut,
                GenderId = request.GenderId,
                Address = addresses,
                Email = emails,
            };
            _context.Person.Add(person);
            await _context.SaveChangesAsync(cancellationToken);

            return person.Id;
        }

     
  
    }
}
