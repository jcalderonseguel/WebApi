using Application.Mediators.IdCountryOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters.Interfaces
{
    public interface ICountryTypePresenter
    {
        IActionResult GetCountryIdQuery(IdentificationCountryVm identificationCountryVm);
    }
}
