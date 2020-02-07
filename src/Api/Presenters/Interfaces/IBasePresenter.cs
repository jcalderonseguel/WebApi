using Microsoft.AspNetCore.Mvc;
using Application.Notifications;

namespace Api.Presenters.Interfaces
{
    interface IBasePresenter
    {
        IActionResult GetActionResult<T, Y>(T result)
            where T : EntityResult<Y>
            where Y : class;
        IActionResult GetActionResult<T>(T result) where T : Result;
    }
}
