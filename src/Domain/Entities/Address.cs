using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public Address()
        {
            this.IdCountry = new HashSet<Country>();
        }

        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<Country> IdCountry { get; set; }
    }
}
