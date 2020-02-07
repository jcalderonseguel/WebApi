using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace Application.System.SeedSampleData
{
    class SampleDataSeeder
    {
        private readonly IPersonDbContext _context;

        private readonly List<Country> Countries = new List<Country>
        {
            new Country {Name = "Chile", IsoCode = "CL"},
            new Country {Name = "Argentina", IsoCode = "AR"},
            new Country {Name = "Brasil", IsoCode = "BR"}
        };

        private readonly List<Gender> Genders = new List<Gender>
        {
            new Gender {Description = "Male"},
            new Gender {Description = "Female"},
            new Gender {Description = "Other"}
        };


        private readonly List<Person> People = new List<Person>
        {
            new Person {Name = "Jeremy", LastName = "Andrades", Rut = "19.107.798-9", GenderId = 3 },
            new Person {Name = "ElNe", LastName = "Kazo", Rut = "19.107.798-0", GenderId = 3 },
            new Person {Name = "Camila", LastName = "Alvarez", Rut = "19.511.552-4", GenderId = 2 },
            new Person {Name = "Sin", LastName = "Genero", Rut = "12.345.678-9", GenderId = 1 }
        };

        private readonly List<Address> Addresses = new List<Address>
        {
            new Address {StreetName = "Los Vivaldis", Number = "1234", PostCode = "1111", PersonId = 1, CountryId = 1},
            new Address {StreetName = "Los Wachiturros", Number = "5678", PostCode = "2222", PersonId = 2, CountryId = 2},
            new Address {StreetName = "Sopa do Macaco", Number = "9101", PostCode = "3333", PersonId = 3, CountryId = 3}
        };

        private readonly List<Email> Emails = new List<Email>
        {
            new Email {Description = "jeremyandrades@gmail.com", PersonId = 3},
            new Email {Description = "camilaalvarez@gmail.com", PersonId = 2},
            new Email {Description = "singenero@gmail.com", PersonId = 1}
        };

        public SampleDataSeeder(IPersonDbContext context)
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

            if (_context.Person.Count() != People.Count)
            {
                await SeedPeopleAsync(cancellationToken);
            }

            if (_context.Address.Count() != Addresses.Count)
            {
                await SeedAddressesAsync(cancellationToken);
            }

            if (_context.Email.Count() != Emails.Count)
            {
                await SeedEmailsAsync(cancellationToken);
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

        private async Task SeedAddressesAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Addresses)
            {
                if (_context.Address.Any(x => x.StreetName == item.StreetName)) continue;
                else _context.Address.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedPeopleAsync(CancellationToken cancellationToken)
        {
            foreach (var item in People)
            {
                if (_context.Person.Any(x => x.Name == item.Name)) continue;
                else _context.Person.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedEmailsAsync(CancellationToken cancellationToken)
        {
            foreach (var item in Emails)
            {
                if (_context.Email.Any(x => x.Description == item.Description)) continue;
                else _context.Email.Add(item);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
