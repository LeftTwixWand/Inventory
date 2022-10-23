using System.Diagnostics;
using BuildingBlocks.Application.CQRS.Queries;

namespace Inventory.Infrastructure.CQRS.Decorators.QueryDiagnostics;

internal sealed class DiagnosticQueryHandlerDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
   where TQuery : IQuery<TResult>
{
    private readonly IQueryHandler<TQuery, TResult> _decorated;

    public DiagnosticQueryHandlerDecorator(IQueryHandler<TQuery, TResult> decorated)
    {
        _decorated = decorated;
    }

    public async Task<TResult> Handle(TQuery query, CancellationToken cancellationToken)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        var result = await _decorated.Handle(query, cancellationToken);

        stopwatch.Stop();

        // TODO: Display the query execution speed.
        return result;
    }
}