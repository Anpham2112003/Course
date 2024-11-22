
using Domain.Types.ErrorTypes.Erros.Cart;
using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Untils;
using Infrastructure.Unit0fWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Cart
{
    public class DeleteCartRequestHandler : IRequestHandler<DeleteCartRequest, MutationPayload<Guid, DeleteCartError>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public DeleteCartRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<MutationPayload<Guid, DeleteCartError>> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
        {
            var errors = new List<DeleteCartError>();

            try
            {
                var userId = _contextAccessor.GetId();

                var cart = await _unitOfWork.cartRepository.FindOneAsync(request.Id);

                if(cart is null)
                {
                    errors.Add(new CartNotFoundError());

                    return new MutationPayload<Guid, DeleteCartError>
                    {
                        errors = errors
                    };
                }

                if(cart.UserId.Equals(userId) is false)
                {
                    errors.Add(new OwnerError());

                    return new MutationPayload<Guid, DeleteCartError>
                    {
                        errors = errors
                    };
                }

                return new MutationPayload<Guid, DeleteCartError>
                {
                    payload = request.Id,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
