
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPersonDbContext
    {
        DbSet< Person > Persons { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<Email> Emails { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
