using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.EmailOperations.Queries
{
    public class IdentificationEmailDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int PersonId { get; set; }
    }
}
