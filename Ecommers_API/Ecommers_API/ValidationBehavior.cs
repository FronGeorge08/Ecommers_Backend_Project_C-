namespace Ecommers_API
{
    using FluentValidation;
    using MediatR;
    using MediatR.Pipeline;

    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IEnumerable<IRequestPreProcessor<TRequest>> _preProcessors;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IEnumerable<IRequestPreProcessor<TRequest>> preProcessors)
        {
            _validators = validators;
            _preProcessors = preProcessors;
        }

        public async Task<TResponse> Handle(
         TRequest request,
         RequestHandlerDelegate<TResponse> next,
         CancellationToken cancellationToken)
        {
            var preProcessors = _preProcessors?.ToList() ?? new List<IRequestPreProcessor<TRequest>>();
            var validators = _validators?.ToList() ?? new List<IValidator<TRequest>>();

            foreach (var pre in preProcessors)
            {
                await pre.Process(request, cancellationToken);
            }

            if (validators.Count > 0)
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                  validators.Select(v => v.ValidateAsync(context, cancellationToken))
                );

                var failures = validationResults
                  .SelectMany(r => r.Errors)
                  .Where(f => f is not null)
                  .GroupBy(f => new { f.PropertyName, f.ErrorMessage })
                  .Select(g => g.First())
                  .ToList();

                if (failures.Count != 0)
                {
                    var msg = string.Join("; ", failures.Select(f => f.ErrorMessage));
                    throw new ValidationException(msg, failures);
                }
            }

            return await next();
        }

    }
}
