using Microsoft.AspNetCore.Mvc;
using Application.Mediators.GenderOperations.Queries;

namespace Api.Presenters.Interfaces
{
    public interface IGenderPresenter
    {
        IActionResult GetGenderByCountry(IdentificationGenderVm identificationGenderVm);
    }
}
