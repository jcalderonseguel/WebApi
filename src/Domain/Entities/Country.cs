using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
