using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public partial class Email
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PersonIdPerson { get; set; }

        public virtual Person Person { get; set; }
    }
}
