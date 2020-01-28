using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public partial class Gender
    {
        public short Id { get; set; }
        public string Description { get; set; }

        public virtual Person Person { get; set; }
    }
}
