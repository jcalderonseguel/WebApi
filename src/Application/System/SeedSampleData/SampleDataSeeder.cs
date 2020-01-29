using Application.Common.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System.SeedSampleData
{
    public class SeedSampleDataSeeder
    {
        private readonly IPersonDbContext _context;

        private readonly List<Country> Countries = new List<Country>{
                new Country { Name = "Chile", IsoCode="CL" },
                new Country { Name = "Argentina", IsoCode="AR" },
                new Country { Name = "Brasil" , IsoCode="BR"},
                new Country { Name = "Bolivia" , IsoCode="BL"}
            };

        private readonly List<Gender> Genders = new List<Gender>{
                new Gender { Description = "Masculino" },
                new Gender { Description = "Femenino" }
            };

        private readonly List<Person> Person = new List<Person>
        {
            new Person { Name ="Manuel", LastName="Vera", Rut="14414961-5", GenderId = 1 },
            new Person { Name ="Reinaldo", LastName="Vera", Rut="11111111-1", GenderId = 1 },
            new Person { Name ="Scarleth", LastName="Vera", Rut="20660567-7", GenderId = 2 },
            new Person { Name ="Patricia", LastName="Guzman", Rut="22222222-2", GenderId = 2 }

        };
        private readonly List<Email> Email= new List<Email>{
                new Email{ Description = "manuel.vera.poblete@gmail.com", PersonId= 1},
                new Email{ Description = "reinaldo@gmail.com", PersonId=2 },
                new Email{ Description = "scarleth@gmail.com", PersonId=3 },
                new Email{ Description = "patricia@gmail.com", PersonId= 4  }
            };
        private readonly List<Address> Address= new List<Address>{
                new Address{StreetName = "Pucon", Number = "293", PostCode = "CL",PersonId = 1, CountryId = 1},
                new Address{StreetName = "Los Alerces", Number = "111", PostCode = "AR",PersonId = 2, CountryId = 2},
                new Address{StreetName = "San Martin", Number = "222", PostCode = "BR",PersonId = 3, CountryId = 3},
                new Address{StreetName = "Anibal Pinto", Number = "333", PostCode = "BL",PersonId = 4, CountryId = 4},

            };

        public SeedSampleDataSeeder(IPersonDbContext context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            if (_context.Country.Count() != Countries.Count)
            {
                await SeedCountriesAsync(cancellationToken);
            }


            if (_context.Gender.Count() != Genders.Count)
            {
                await SeedGendersAsync(cancellationToken);
            }

            if (_context.Person.Count() != Person.Count)
            {
                await SeedPersonAsync(cancellationToken);
            }

            if (_context.Email.Count() != Email.Count)
            {
                await SeedEmailAsync(cancellationToken);
            }
            
            if (_context.Address.Count() != Address.Count)
            {
                await SeedAddressAsync(cancellationToken);
            }

        }
        private async Task SeedCountriesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Countries)
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

        private async Task SeedPersonAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Person)
            {
                if (_context.Person.Any(x => x.Name == item.Name)) continue;
                else _context.Person.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
        private async Task SeedEmailAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Email)
            {
                if (_context.Email.Any(x => x.Description == item.Description)) continue;
                else _context.Email.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        private async Task SeedAddressAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Address)
            {
                if (_context.Address.Any(x => x.StreetName == item.StreetName)) continue;
                else _context.Address.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
