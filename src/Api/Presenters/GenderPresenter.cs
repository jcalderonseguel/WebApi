using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mediators.PersonOperations.GetGender;
using Api.Presenters.Interfaces;

namespace Api.Presenters
{
    public class GenderPresenter : IGenderPresenter
    {
        public IActionResult GetGenderN(GenderInfoDto genderInfoDto)
        {
            CustomResult result = new CustomResult();
            if (genderInfoDto != null)
            {
                result.Content = genderInfoDto;
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
                result.Content = new {  Id };

            }
            return new JsonResult(result);

        }
        }
    }

