using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Options
{
    public class StripeOption
    {
        public const string Stripe = "Payment:Stripe";

        public string? ApiKey { get; set; }
        public string? SecretKey {  get; set; }
        public string? SuccessUrl {  get; set; }
        public string? CancelUrl {  get; set; }
    }
}
