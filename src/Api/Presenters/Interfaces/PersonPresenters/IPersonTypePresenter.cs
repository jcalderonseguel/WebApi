using Application.Mediators.PersonOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presenters.Interfaces.PersonPresenters
{
    public interface IPersonTypePresenter
    {
        IActionResult GetPersonIdQuery(IdentificationPersonVm identificationPersonVm);
    }
}
