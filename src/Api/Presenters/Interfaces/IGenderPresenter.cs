using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mediators.PersonOperations.GetGender;

namespace Api.Presenters.Interfaces
{
    public interface IGenderPresenter
    {

        IActionResult GetGenderN(GenderInfoDto genderInfoDto);
        IActionResult InsertResult(int Id);
    }
}
