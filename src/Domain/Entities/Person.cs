using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Person
    {
        public Person()
        {
            this.IdGender = new HashSet<Gender>();
            this.IdEmail = new HashSet<Email>();
            this.IdAddress = new HashSet<Address>();
        }

        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
       
        public virtual ICollection<Address> IdAddress { get; set; }
        public virtual ICollection<Gender> IdGender { get; set; }
        public virtual ICollection<Email> IdEmail { get; set; }
    }
}
