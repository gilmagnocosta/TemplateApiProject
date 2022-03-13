using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TemplateApiProject.Application.Notifications;
using TemplateApiProject.Application.Requests;
using TemplateApiProject.Application.Responses;
using TemplateApiProject.Domain.Entity;
using TemplateApiProject.Domain.Enums;
using TemplateApiProject.Domain.Interface.Service;
using TemplateApiProject.Domain.Notifications;
using System.Linq;
using System.Collections.Generic;
using AutoMapper.Internal;

namespace TemplateApiProject.Application.Handlers.Requests
{
    class CreateUserHandler: IRequestHandler<CreateUserRequest, Response>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserHandler(IMapper mapper, IMediator mediator, NotificationContext notificationContext, IUserService service)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _service = service;
            _mediator = mediator;
        }

        public async Task<Response> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<CreateUserRequest, User>(request);

            await _service.AddNewAsync(user);

            if (!_notificationContext.HasNotifications)
            {
                await _mediator.Publish(new CreateUserNotification() { 
                    Email = user.Person.Contact.Email, 
                    FirstName = user.Person.FirstName 
                });
            }

            return await Task.FromResult(new Response(user.Id));
        }
    }
}
