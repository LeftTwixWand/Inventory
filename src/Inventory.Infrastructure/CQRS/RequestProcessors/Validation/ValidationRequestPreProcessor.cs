using System.Text;
using FluentValidation;
using FluentValidation.Results;
using MediatR.Pipeline;

namespace Inventory.Infrastructure.CQRS.RequestProcessors.Validation;

internal sealed class ValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly IList<IValidator<TRequest>> _validators;

    public ValidationRequestPreProcessor(IList<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        List<ValidationFailure> errors = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(error => error is not null)
            .ToList();

        if (errors.Any())
        {
            StringBuilder errorBuilder = new();

            _ = errorBuilder.AppendLine("Invalid command, reason: ");

            errors.ForEach(error => errorBuilder.AppendLine(error.ErrorMessage));

            throw new ValidationException(errorBuilder.ToString());
        }

        return Task.CompletedTask;
    }
}