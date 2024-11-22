using Application.MediaR.Comands.Payment;
using Domain.Types.ErrorTypes.Unions.Payment;
using Domain.Untils;
using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Stripe.Checkout;

namespace Api.Schemas.Mutation
{
    [ExtendObjectType(typeof(Mutations))]
    public class PaymentMutation
    {
        
    }
}
