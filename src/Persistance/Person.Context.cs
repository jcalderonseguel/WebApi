using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Common.Interfaces;

namespace Persistance

{
    public class PersonDbContext :DbContext, IPersonDbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Person)
                      .WithMany(p => p.Address)
                      .HasForeignKey(d => d.PersonId)
                      .HasConstraintName("FK_PersonHasAddress");
                
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Address> AddressSet { get; set; }
        public virtual DbSet<Country> CountrySet { get; set; }
        public virtual DbSet<Person> PersonSet { get; set; }
        public virtual DbSet<Gender> GenderSet { get; set; }
        public virtual DbSet<Email> EmailSet { get; set; }
    }
}
