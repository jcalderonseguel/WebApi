﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class Email
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
