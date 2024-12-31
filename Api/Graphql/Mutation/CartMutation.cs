using Application.MediaR.Comands.Cart;
using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using MediatR;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class CartMutation
    {

        [Authorize]
        public async Task<MutationPayload<CreateCartRequest,CreateCartError>> createCart([Service] IMediator mediator,CreateCartRequest input,CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }

        [Authorize]
        public async Task<MutationPayload<Guid, DeleteCartError>> deleteCart([Service] IMediator mediator, DeleteCartRequest input, CancellationToken cancellation)
        {
            var result = await mediator.Send(input, cancellation);

            return result;
        }
    }
}
