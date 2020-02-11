using Application.Mediators.CountryOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters.Interfaces
{
    public interface ICountryPresenter
    {
        IActionResult GetCountryById(CountryVm countryVm);
    }
}
