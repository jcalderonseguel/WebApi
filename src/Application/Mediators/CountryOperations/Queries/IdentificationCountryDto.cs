using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.IdCountryOperations.Queries
{
    public class IdentificationCountryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
    }
}
