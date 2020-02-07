using Microsoft.AspNetCore.Mvc;
using Application.Mediators.GenderOperations.Queries;
using Api.Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters
{
    public interface GenderPresenter : IGenderPresenter
    {
        public IActionResult GetGenderById(IdentificationGenderVm identificationGenderVm)
        {
            CustomResult result = new CustomResult();

            if (identificationGenderVm != null && identificationGenderVm.idGenderList.Any())
            {
                result.Content = identificationGenderVm.idGenderList;
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
