using Api.Presenters.Interfaces.GenderPresenters;
using Application.Mediators.GenderOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Presenters
{
    public class GenderPresenter : IGenderTypePresenter
    {
        public IActionResult GetGenderIdQuery(IdentificationGenderVm identificationGenderVm)
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
