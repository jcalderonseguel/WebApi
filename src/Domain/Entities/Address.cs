using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Person Person { get; set; }
    }
}
