using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.Insert
{
    public class InsertGender : IRequest<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }

        public class InsertHandler : IRequestHandler<InsertGender, int>
        {
            private readonly IPersonDbContext _context;
            public InsertHandler(IPersonDbContext context)
            {
                _context = context;

            }
            public async Task<int> Handle(InsertGender request, CancellationToken cancellationToken)
            {

                Gender gender = new Gender
                {

                    Description = request.Description

                };
                _context.Gender.Add(gender);
                await _context.SaveChangesAsync(cancellationToken);

                return gender.Id;
            }

        }
    
}
