using MediatR;
using TemplateApiProject.Application.Notifications.Base;

namespace TemplateApiProject.Application.Notifications
{
    public class CreateUserNotification : NotificationBase, INotification
    {
        public string FirstName { get; set; }
    }
}
