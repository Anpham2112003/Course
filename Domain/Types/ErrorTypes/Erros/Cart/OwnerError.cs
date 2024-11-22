using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Types.ErrorTypes.Unions.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Cart
{
    public class OwnerError : DeleteCartError,PaymentError
    {
        public string? code { get; set; }=nameof(OwnerError);
        public string? message { get; set; } = "You are not the owner!";
    }
}
