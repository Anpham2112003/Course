using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Application.MediaR.Pipeline
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest where TResponse : class
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationPipeline(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _validator.ValidateAsync(request, cancellationToken);

                if (result.IsValid)
                {
                    return await next();
                }
                else
                {
                    throw new FluentValidation.ValidationException(result.Errors);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
