using Microsoft.AspNetCore.Mvc;
using Api.Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mediators.CountryOperations;

namespace Api.Presenters
{
    public class CountryPresenter : ICountryPresenter
    {
        public IActionResult GetCountryById(CountryVm countryVm)
        {
            CustomResult result = new CustomResult();
            if (countryVm != null && countryVm.CountryList.Any())
            {
                result.Content = countryVm.CountryList;
            }
            else
            {
                result.StatusCode = 404;
                result.Message = "No Content";
            }
            return new JsonResult(result);
        }

    }
}
