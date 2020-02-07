using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Presenters.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Api.Presenters
{
    public class PersonPresenter : IPersonPresenter
    {
        public IActionResult InsertResult(int Id)
        {
            CustomResult result = new CustomResult();

            if(Id > 0)
            {
                result.Message = "Created";
                result.StatusCode = 201;
                result.Content = new { Id };
            }

            return new JsonResult(result);
        }
    }
}
