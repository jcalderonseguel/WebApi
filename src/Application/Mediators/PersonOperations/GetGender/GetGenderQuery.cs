using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediators.PersonOperations.GetGender
{
    public class GetGenderQuery : IRequest<GenderInfoDto>
    {

        public int Id { get; set; }

        public GetGenderQuery(int Id)
        {

            this.Id = Id;

        }
    }

        public class GetGenderQueryHandler : IRequestHandler<GetGenderQuery, GenderInfoDto>
        {
            private readonly IPersonDbContext _context;
            public GetGenderQueryHandler(IPersonDbContext context)
            {
                _context = context;
            }

            public async Task<GenderInfoDto> Handle(GetGenderQuery request, CancellationToken cancellationToken)
            {
                var list = await _context.Gender.Select(x => new GenderInfoDto
                {
                    Id = x.Id,
                    Description = x.Description
                    

                }).Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                return list;
            }
        }
}
