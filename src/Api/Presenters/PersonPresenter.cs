using Api.Presenters.Interfaces;
using Application.Mediators.PersonOperations.GetPersonByDocumentNumber;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters
{
    public class PersonPresenter : IPersonPresenter
    {
        public IActionResult GetPersonByDocumentNumber(PersonInfoDto personInfoDto)
        {
            CustomResult result = new CustomResult();
            if(personInfoDto != null)
            {
                result.Content = personInfoDto;
            }
            else
            {
                result.StatusCode = 404;
                result.Message = "No Content";
            }
            return new JsonResult(result);
        }
        public IActionResult InsertResult(int Id)
        {
            CustomResult result = new CustomResult();
            if (Id > 0)
            {
                result.Message = "Created";
                result.StatusCode = 201;
                result.Content = new { Id = Id };

            }
            return new JsonResult(result);

        }
    }
}
