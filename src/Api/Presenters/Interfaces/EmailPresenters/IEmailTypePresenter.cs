using Microsoft.AspNetCore.Mvc;
using Application.Mediators.EmailOperations.Queries;

namespace Api.Presenters.Interfaces.EmailPresenters
{
    public interface IEmailTypePresenter
    {
        IActionResult GetEmailIdQuery(IdentificationEmailVm identificationEmailVm);
    }
}
