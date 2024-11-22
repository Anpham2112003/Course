using Domain.DTOs;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Payment
{
    public interface IStripService
    {
        public  Task<Session> CreateSesssion(OrderDTO order);
    }
}
