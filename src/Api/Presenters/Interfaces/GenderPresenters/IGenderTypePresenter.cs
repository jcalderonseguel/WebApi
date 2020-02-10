using Application.Mediators.GenderOperations.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presenters.Interfaces.GenderPresenters
{
    public interface IGenderTypePresenter
    {
        IActionResult GetGenderIdQuery(IdentificationGenderVm identificationGenderVm);
    }
}
