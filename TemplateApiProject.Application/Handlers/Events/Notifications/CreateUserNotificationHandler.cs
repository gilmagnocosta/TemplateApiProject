using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TemplateApiProject.Application.Notifications;

namespace TemplateApiProject.Application.Handlers.Requests.Events
{
    public class CreateUserNotificationHandler : INotificationHandler<CreateUserNotification>
    {
        public CreateUserNotificationHandler()
        {
        }

        public async Task Handle(CreateUserNotification notification, CancellationToken cancellationToken)
        {
            
        }
    }
}
