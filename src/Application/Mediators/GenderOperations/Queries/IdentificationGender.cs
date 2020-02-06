using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mediators.GenderOperations.Queries
{
    public class IdentificationGenderDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }

    public class IdentificationGenderVm
    {
        public IList<IdentificationGenderDto> idGenderList { get; set; }
    }

}
