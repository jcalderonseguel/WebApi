using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistance

{
    public class Person
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
        public virtual DbSet<Person> PersonSet { get; set; }
        public virtual DbSet<Gender> GenderSet { get; set; }
        public virtual DbSet<Email> EmailSet { get; set; }
    }
}
