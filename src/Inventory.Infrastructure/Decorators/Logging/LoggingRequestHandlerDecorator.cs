using BuildingBlocks.Application.Requests;
using MediatR;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;

namespace Inventory.Infrastructure.Decorators.Logging;

internal sealed class LoggingRequestHandlerDecorator<TRequest> : IRequestHandler<TRequest>
         where TRequest : RequestBase
{
    private readonly ILogger _logger;
    private readonly IRequestHandler<TRequest> _decorated;

    public LoggingRequestHandlerDecorator(ILogger logger, IRequestHandler<TRequest> decorated)
    {
        _logger = logger;
        _decorated = decorated;
    }

    public async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
    {
        using var pushResult = LogContext.Push(new RequestLogEnricher(request));

        try
        {
            _logger.Information("Executing request {@Request}", request);

            var result = await _decorated.Handle(request, cancellationToken);

            _logger.Information("Request executed successful, result {Result}", result);

            return result;
        }
        catch (Exception exception)
        {
            _logger.Error(exception, "Request processing failed");
            throw;
        }
    }

    private sealed class RequestLogEnricher : ILogEventEnricher
    {
        private readonly RequestBase _request;

        public RequestLogEnricher(RequestBase request)
        {
            _request = request;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"Request:{_request.RequestId}")));
        }
    }
}