using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    public partial class Country{
        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }

        public virtual Address Address { get; set; }
    }
}
