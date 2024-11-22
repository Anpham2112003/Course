using Domain.DTOs;
using Domain.Interfaces.Payment;
using Domain.Options;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Infrastructure.Services.PaymentService;

public class StripeService:IStripService
{
    private readonly IOptionsMonitor<StripeOption> _option;

    public StripeService(IOptionsMonitor<StripeOption> option)
    {
        _option = option;

        
    }

    public async Task<Session> CreateSesssion(OrderDTO order)
    {


        var options = new SessionCreateOptions
        {
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData=new SessionLineItemPriceDataOptions
                    {
                        Currency = order.Currency,
                        UnitAmountDecimal=(decimal)order.Amount,
                        ProductData=new SessionLineItemPriceDataProductDataOptions
                        {
                            Images=new List<string>
                            {
                                order.Thumbnail!
                            },
                            Name=order.Name,
                            
                        },
                        
                    },

                    Quantity=1,                 
                                    
                }
            },
            Currency=order.Currency,
            Mode="payment",
            SuccessUrl=_option.CurrentValue.SuccessUrl,
            CancelUrl=_option.CurrentValue.CancelUrl,
            Metadata=new Dictionary<string, string>
            {
                {"userId",order.UserId.ToString()},
                {"courseId",order.CourseId.ToString()},
                {"cartId",order.Id.ToString() }
                
            }
            
        };

        var session = new SessionService();

       
        
       return await session.CreateAsync(options,new RequestOptions { ApiKey=_option.CurrentValue.SecretKey});
       
    }
}