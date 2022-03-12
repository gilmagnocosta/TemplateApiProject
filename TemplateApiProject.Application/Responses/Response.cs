using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateApiProject.Domain.Notifications;

namespace TemplateApiProject.Application.Responses
{
    public class Response
    {
        public object Content { get; set; }
        public List<Notification> Errors { get; set; }
        public bool HasErrors => Errors != null && Errors.Any();

        public Response() { }

        public Response(object content)
        {
            Content = content;
        }

        public void AddError(Notification notification)
        {
            if (Errors == null) Errors = new List<Notification>();
            Errors.Add(notification);
        }

        /// <summary>
        /// Check if exists errors to notificate. If exists add them to errors list.
        /// </summary>
        /// <param name="notificationContext">NotificationContext Object</param>
        public void CheckNotifications(NotificationContext notificationContext)
        {
            if (notificationContext.HasNotifications)
            {
                foreach (var item in notificationContext.Notifications)
                {
                    AddError(item);
                }
            }
        }
    }
}
