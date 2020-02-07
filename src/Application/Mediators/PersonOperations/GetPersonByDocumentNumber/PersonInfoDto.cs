using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.PersonOperations.GetPersonByDocumentNumber
{
    public class PersonInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rut { get; set; }
        public int GenderId { get; set; }
    }
}

