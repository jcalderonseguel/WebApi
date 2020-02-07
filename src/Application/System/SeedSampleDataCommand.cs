using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommnandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IPersonDbContext _context;

        public SeedSampleDataCommnandHandler(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);
            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
