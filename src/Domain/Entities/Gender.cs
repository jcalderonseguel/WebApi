using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
