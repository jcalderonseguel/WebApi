﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
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
    
        public virtual DbSet<Person> PersonSet { get; set; }
        public virtual DbSet<Address> AddressSet { get; set; }
        public virtual DbSet<Country> CountrySet { get; set; }
        public virtual DbSet<Gender> GenderSet { get; set; }
        public virtual DbSet<Email> EmailSet { get; set; }
    }
}
