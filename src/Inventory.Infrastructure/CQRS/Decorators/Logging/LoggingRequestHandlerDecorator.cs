using BuildingBlocks.Application.CQRS.Requests;
using MediatR;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;

namespace Inventory.Infrastructure.CQRS.Decorators.Logging;

internal sealed class LoggingRequestHandlerDecorator<TRequest> : IRequestHandler<TRequest>
    where TRequest : IIdentifiableRequest
{
    private readonly ILogger _logger;
    private readonly IRequestHandler<TRequest> _decorated;

    public LoggingRequestHandlerDecorator(ILogger logger, IRequestHandler<TRequest> decorated)
    {
        _logger = logger;
        _decorated = decorated;
    }

    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        using var pushResult = LogContext.Push(new RequestLogEnricher(request));

        try
        {
            _logger.Information("Executing request {@Request}", request);

            await _decorated.Handle(request, cancellationToken);

            _logger.Information("Request executed successful");
        }
        catch (Exception exception)
        {
            _logger.Error(exception, "Request processing failed");
            throw new Exception("Exception happens while operation execution.", exception);
        }
    }

    private sealed class RequestLogEnricher : ILogEventEnricher
    {
        private readonly IIdentifiableRequest _request;

        public RequestLogEnricher(IIdentifiableRequest request)
        {
            _request = request;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"Request:{_request.RequestId}")));
        }
    }
}

internal sealed class LoggingRequestHandlerDecorator<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IIdentifiableRequest<TResult>
{
    private readonly ILogger _logger;
    private readonly IRequestHandler<TRequest, TResult> _decorated;

    public LoggingRequestHandlerDecorator(ILogger logger, IRequestHandler<TRequest, TResult> decorated)
    {
        _logger = logger;
        _decorated = decorated;
    }

    public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
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

            throw new Exception("Exception happens while operation execution.", exception);
        }
    }

    private sealed class RequestLogEnricher : ILogEventEnricher
    {
        private readonly IIdentifiableRequest<TResult> _request;

        public RequestLogEnricher(IIdentifiableRequest<TResult> request)
        {
            _request = request;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"Request:{_request.RequestId}")));
        }
    }
}