using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorTest.Mediator.Behavior
{
    public class LogBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LogBehavior<TRequest, TResponse>> _logger;

        public LogBehavior(ILogger<LogBehavior<TRequest, TResponse>> logger)
            => _logger = logger;
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Executing {request.GetType().Name}");
            TResponse response = await next();
            _logger.LogInformation($"Executed {request.GetType().Name}");
            return response;
        }
    }
}
