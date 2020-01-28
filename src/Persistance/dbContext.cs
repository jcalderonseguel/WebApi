using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PersonContainer : DbContext
    {
        public PersonContainer()
            : base("name=PersonContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> AddressSet { get; set; }
        public virtual DbSet<Country> CountrySet { get; set; }
        public virtual DbSet<Gender> GenderSet { get; set; }
        public virtual DbSet<Person> PersonSet { get; set; }
        public virtual DbSet<Email> EmailSet { get; set; }
    }
}
