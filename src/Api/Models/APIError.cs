using Flunt.Notifications;
using Application.Notifications;
using System.Collections.Generic;

namespace Api.Models
{
    public class ApiError
    {
        public ApiError() { }

        public ApiError(IEnumerable<Notification> errors, ErrorCode? error = null)
        {
            this.ErrorType = error;
            this.Errors = errors;
        }

        public ErrorCode? ErrorType { get; private set; }

        public IEnumerable<Notification> Errors { get; private set; }

        public static ApiError FromResult(Result result)
        {
            return new ApiError(result.Notifications, result.Error);
        }
    }
}
