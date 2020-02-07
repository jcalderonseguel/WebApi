using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System
{
    public class SampleDataSeeder
    {
        private readonly IPersonDbContext _context;

        private readonly List<Country> countries = new List<Country>
        {
            new Country{Name="Chile", IsoCode="CL"},
            new Country{Name="Argentina", IsoCode="AR"},
            new Country{Name="Brasil", IsoCode="BR"},
        };
        private readonly List<Gender> Genders = new List<Gender>
        {
            new Gender{Description="Male"},
            new Gender{Description="Female"}

        };


        public SampleDataSeeder(IPersonDbContext context)
        {
            _context = context;
        }
        public async Task SeedAllAsync(CancellationToken cancellationToken)

        {
            if(_context.Country.Count()!=countries.Count)
            {
                await SeedCountriesAsync(cancellationToken);
            }
            if (_context.Gender.Count() != Genders.Count)
            {
                await SeedGendersAsync(cancellationToken);
            }
        }

        private async Task SeedCountriesAsync(CancellationToken cancellationToken)
        {
            foreach(var item in countries)
            {
                if (_context.Country.Any(x => x.Name == item.Name)) continue;
                else _context.Country.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
           
        }
        private async Task SeedGendersAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Genders)
            {
                if (_context.Gender.Any(x => x.Description == item.Description)) continue;
                else _context.Gender.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
