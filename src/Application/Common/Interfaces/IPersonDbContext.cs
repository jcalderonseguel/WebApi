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
         DbSet<Person> Person { get; set; }
         DbSet<Address> Address { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
