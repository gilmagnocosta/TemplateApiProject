using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TemplateApiProject.Application.Responses;
using TemplateApiProject.Domain.Notifications;

namespace TemplateApiProject.Application.PipelineBehaviors
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : Response
    {
        private readonly IEnumerable<IValidator> _validators;
        private static NotificationContext _notificationContext;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators, NotificationContext notificationContext)
        {
            _validators = validators;
            _notificationContext = notificationContext;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<object>(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new Response();

            foreach (var failure in failures)
            {
                response.AddError(new Notification(failure.PropertyName, failure.ErrorMessage));
            }
            
            _notificationContext.AddNotifications(response.Errors as ICollection<Notification>);

            return Task.FromResult(response as TResponse);
        }
    }
}
