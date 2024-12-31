using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Payment
{
    public class StripeWebhookRequest:IRequest
    {
        public string? BankTransationId { get; set; }
        public string? Email { get; set; }
        public Guid UserId { get; set; }
        public Guid CartId { get; set; }
        public Guid CourseId { get; set; }
        public float Amount {  get; set; }
       
    }
}
