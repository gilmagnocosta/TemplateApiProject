using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace TemplateApiProject.Application.PipelineBehaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            //Logging.Info($"Handling {typeof(TRequest).Name}");
            Log.Information($"Handling {typeof(TRequest).Name}");
            var response = await next();
            //Logging.Info($"Handled {typeof(TResponse).Name}");
            Log.Information($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
