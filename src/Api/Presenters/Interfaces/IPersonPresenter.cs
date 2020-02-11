using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Mediators.PersonOperations.Queries;
using Application.Mediators.PersonOperations.GetPersonByDocumentNumber;

namespace Api.Presenters.Interfaces
{
    public interface IPersonPresenter
    {
        IActionResult InsertResult(int Id);
        IActionResult GetPersonByDocumentNumber(PersonInfoDto personInfoDto);
    }
}
