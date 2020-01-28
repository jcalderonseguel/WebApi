using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public string name { get; set; }
        public int IdPerson { get; set; }
        public int IdCountry { get; set; }

        public virtual Person Person { get; set; }
        public virtual Country Country { get; set; }
    }
}
