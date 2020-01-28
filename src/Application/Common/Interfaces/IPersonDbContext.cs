using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPersonDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<Country> Country{ get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<Email> Email { get; set; }
        DbSet<Gender> Gender { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
