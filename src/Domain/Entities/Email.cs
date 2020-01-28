using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    public partial class Email
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual Person Person { get; set; }
    }
}
