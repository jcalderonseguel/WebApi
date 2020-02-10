using Api.Presenters.Interfaces.EmailPresenters;
using Application.Mediators.EmailOperations.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters
{
    public class EmailPresenter : IEmailTypePresenter
    {
        public IActionResult GetEmailIdQuery(IdentificationEmailVm identificationEmailVm)
        {
            CustomResult result = new CustomResult();
            if (identificationEmailVm != null && identificationEmailVm.idEmailList.Any())
            {
                result.Content = identificationEmailVm.idEmailList;
            }
            else
            {
                result.StatusCode = 404;
                result.Message = " No Content";
            }
            return new JsonResult(result);
        }
    }
}
