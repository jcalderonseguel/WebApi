using Application.Mediators.PersonOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presenters.Interfaces.PersonPresenters
{
    public interface IPersonPresenter
    {
        IActionResult GetPerson(IdentificationPersonDto identificationPersonDto);
        IActionResult InsertResult(long PersonId);
    }
}
