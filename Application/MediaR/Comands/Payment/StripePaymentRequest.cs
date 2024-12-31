using Application.MediaR.Pipeline;
using Domain.Types.ErrorTypes.Unions.Payment;
using Domain.Untils;
using MediatR;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Payment
{
    public class StripePaymentRequest:IRequest<MutationPayload<Session,PaymentError>>,IRequireValidation
    {
        public Guid CartId { get; set; }
    }
}
