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
    public class PersonDbContext :DbContext,IPersonDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        
        {
            modelBuilder.Entity<Address>(entity =>
           {
               entity.HasOne(d => d.Person)
                     .WithMany(p => p.Address)
                     .HasForeignKey(d => d.IdPerson)
                     .HasConstraintName("FK_PersonHasAddress");
           });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Country)
                      .WithMany(p => p.Address)
                      .HasForeignKey(d => d.IdCountry)
                      .HasConstraintName("FK_CountryHasAddress");
            });


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        public  virtual DbSet<Person> Person { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Address> Address { get; set ; }
        public DbSet<Email> Email { get ; set ; }
        public DbSet<Gender> Gender { get ; set ; }
    }
}
