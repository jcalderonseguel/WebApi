﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PersonIdPerson { get; set; }
    }
}
