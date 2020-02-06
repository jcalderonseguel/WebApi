using System.Collections.Generic;

namespace Api.Presenters
{
    public class CustomResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Content { get; set; }
        public IDictionary<string, string[]> Notifications { get; set; }

        public CustomResult()
        {
            StatusCode = 200;
            Message = "Success";
        }
    }
}
