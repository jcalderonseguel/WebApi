using System.Collections.Generic;
using Flunt.Notifications;

namespace Application.Notifications
{
    public class Result : Notifiable
    {
        public Result(IReadOnlyCollection<Notification> notifications)
        {
            this.AddNotifications(notifications);
        }

        public Result(string error)
        {
            this.AddNotification(null, error);
        }

        public void AddNotification(string error)
        {
            this.AddNotification(null, error);
        }

        public void AddNotification(string error, ErrorCode errorCode)
        {
            this.AddNotification(null, error);
            this.Error = errorCode;
        }

        public void AddNotification(string property, string message, ErrorCode errorCode)
        {
            this.AddNotification(property, message);
            this.Error = errorCode;
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications, ErrorCode errorCode)
        {
            this.AddNotifications(notifications);
            this.Error = errorCode;
        }

        public ErrorCode? Error { get; set; }
    }
}
