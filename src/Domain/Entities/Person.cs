using System;
using System.Collections.Generic;

namespace Domain.Entities
{
   public class Person
    {
        public Person()
        {
            this.Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
