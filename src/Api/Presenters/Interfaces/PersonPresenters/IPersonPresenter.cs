using Microsoft.AspNetCore.Mvc;

namespace Api.Presenters.Interfaces.PersonPresenters
{
    public interface IPersonPresenter
    {
        IActionResult InsertResult(long PersonId);
    }
}
