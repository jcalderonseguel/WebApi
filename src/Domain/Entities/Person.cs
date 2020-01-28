using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Person
    { 
        public Person()
        {
            Email = new HashSet<Email>();
            Address = new HashSet<Address>();
        }

        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public virtual Gender Gender { get; set; }
        
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Email> Email { get; set; }
    }
}
