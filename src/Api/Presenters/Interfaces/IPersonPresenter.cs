using Application.Mediators.PersonOperations.GetPersonByDocumentNumber;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Presenters.Interfaces
{
    public interface IPersonPresenter
    {

        IActionResult GetPersonByDocumentNumber(PersonInfoDto personInfoDto);
        IActionResult InsertResult(int Id);


    }
}
