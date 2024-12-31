using Domain.Entities;
using Infrastructure.Unit0fWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.Mailer;
using Hangfire;
using Infrastructure.Services.MailService;

namespace Application.MediaR.Comands.Payment
{
    public class StripeWebHookRequestHandler : IRequestHandler<StripeWebhookRequest>
    {
        private readonly IUnitOfWork _unitOfWork;

        public StripeWebHookRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(StripeWebhookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await _unitOfWork.cartRepository.FindOneAsync(request.CartId);

                if(cart is not null)
                {
                    _unitOfWork.cartRepository.DeleteOne(cart);
                }
                var payment = new PaymentEntity
                {
                    Id = Guid.NewGuid(),
                    Amount = request.Amount,
                    CourseId = request.CourseId,
                    BankTransactionId = request.BankTransationId,
                    PaymentMethod = Domain.Types.EnumTypes.EnumPaymentMethod.Stripe,
                    UserId = request.UserId,
                };

                var pucharse = new PurchaseEntity
                {
                    Id = Guid.NewGuid(),
                    CourseId = request.CourseId,
                    UserId = request.UserId,
                };

                var tk = _unitOfWork.paymentRepository.AddOneAsync(payment);

                var tk2 = _unitOfWork.purchaseRepository.AddOneAsync(pucharse);
                
                await Task.WhenAll(tk, tk2);

                await _unitOfWork.SaveChangesAsync();

                BackgroundJob.Enqueue<IMailerService>( x => x.SendMailAsync(new MailObject
                {
                    To = request.Email,
                    Subject = "Thank you purchased!",
                    Body = "You have been purchased Course!",
                },cancellationToken));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
