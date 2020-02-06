using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Application.Notifications;
using Api.Presenters.Interfaces;

namespace Api.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        public virtual IActionResult GetActionResult<T>(T result)
            where T : Result
        {
            if (result.Invalid)
            {
                return CreateErrorResult(result);
            }

            return new OkResult();
        }

        public virtual IActionResult GetActionResult<T, Y>(T result)
            where Y : class 
            where T : EntityResult<Y>
        {
            if (result.Error != null)
            {
                return CreateErrorResult(result);
            }

            var res = new JsonResult(result.Entity)
            {
                StatusCode = 200
            };
            return res;
        }

        protected virtual IActionResult CreateErrorResult<T>(T result)
            where T : Result
        {
            var errorBody = ApiError.FromResult(result);
            switch (result.Error)
            {
                case ErrorCode.NotFound: return new NotFoundObjectResult(errorBody);
                case ErrorCode.Business: return new UnprocessableEntityObjectResult(errorBody);
                case ErrorCode.Unauthorized: return new UnauthorizedObjectResult(errorBody);
                case ErrorCode.BadRequest: return new BadRequestObjectResult(errorBody);
                default: return new BadRequestObjectResult(errorBody);
            }
        }
    }
}
