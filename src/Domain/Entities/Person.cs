using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public partial class Person
    { 
        public Person()
        {
            this.Email = new HashSet<Email>();
            this.Address = new HashSet<Address>();
        }

        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public virtual ICollection<Email> Email { get; set; }
        public virtual Gender Gender { get; set; }
        
        public virtual ICollection<Address> Address { get; set; }
    }
}
