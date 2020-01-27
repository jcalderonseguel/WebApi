using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
