using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Persistance
{
    class PersonDbContext :DbContext, IPersonDbContext
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
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonHasAddress");

            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Address { get; set; }
    }
}
