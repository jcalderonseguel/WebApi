using Api.Presenters.Interfaces.PersonPresenters;
using Application.Mediators.PersonOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Presenters
{
    public class PersonPresenter : IPersonTypePresenter
    {
        public IActionResult GetPersonIdQuery(IdentificationPersonVm identificationPersonVm)
        {
            CustomResult result = new CustomResult();
            if(identificationPersonVm != null && identificationPersonVm.idPersonList.Any())
            {
                result.Content = identificationPersonVm.idPersonList;
            }
            else
            {
                result.StatusCode = 404;
                result.Message = "No Content";
            }
            return new JsonResult(result);
        }
        public IActionResult InsertResult(long PersonId)
        {
            CustomResult result = new CustomResult();
            if (PersonId > 0)
            {
                result.Message = "Created";
                result.StatusCode = 201;
                result.Content = new { personId = PersonId };
            }

            return new JsonResult(result);
        }
    }
}
