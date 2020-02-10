using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.AddressOperations.Queries
{
    public class IdentificationAddressDto
    {
        public long Id { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
        public long PersonId { get; set; }
        public long CountryId { get; set; }
    }
}
