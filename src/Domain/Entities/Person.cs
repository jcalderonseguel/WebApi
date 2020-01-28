using System;
using System.Collections.Generic;

namespace Domain.Entities
{
   public class Person
    {
        public Person()
        {
            Address = new HashSet<Address>();
            Email = new HashSet<Email>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public int GenderId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Email> Email { get; set; }
    }
}
