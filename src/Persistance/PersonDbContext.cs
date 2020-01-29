using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistance
{

    public class PersonDbContext : DbContext, IPersonDbContext
    {

        public PersonDbContext(DbContextOptions<PersonDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.PersonId);

            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
    }
}