using Application.Mediators.PersonOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters.Interfaces.PersonPresenters
{
    public interface IPersonTypePresenter
    {
        IActionResult GetPersonIdQuery(IdentificationPersonVm identificationPersonVm);
    }
}
