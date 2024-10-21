using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation.Results;
using FluentValidation;

namespace Application.MediaR.Pipeline
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest:IRequest<TResponse>,IRequireValidation
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationPipeline(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
           
                var result = await _validator.ValidateAsync(request, cancellationToken);

                if (result.IsValid)
                {
                   return await next();
                }
                else
                {
                    throw new ValidationException(result.Errors);
                }

            }
           
        
    }
}
