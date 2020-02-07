using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
                entity.HasIndex(e => e.CountryId)
                    .HasName("IX_FK_CountryAddress");

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_FK_PersonAddress");

                entity.Property(e => e.Number).IsRequired();

                entity.Property(e => e.PostCode).IsRequired();

                entity.Property(e => e.StreetName).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountryAddress");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonAddress");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.IsoCode).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_FK_PersonEmail");

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Email)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonEmail");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.GenderId)
                    .HasName("IX_FK_GenderPerson");

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Rut).IsRequired();

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GenderPerson");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Person> Person { get; set; }
    }
}
