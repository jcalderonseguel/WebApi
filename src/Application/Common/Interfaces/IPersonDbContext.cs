using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public class IPersonDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<Address> Address { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
