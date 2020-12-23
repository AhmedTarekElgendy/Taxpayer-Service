using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Taxpayer.Application.PipelineBehavior
{
    public class ValidationBehavior<TRequest , TResponse> : IPipelineBehavior<TRequest,TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable< IValidator<TRequest>> validatorsi)
        {
            this.validators = validatorsi;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return await next();
                
        }
    }
}
