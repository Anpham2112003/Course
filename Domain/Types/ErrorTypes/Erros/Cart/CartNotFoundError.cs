using Domain.Types.ErrorTypes.Unions.Cart;
using Domain.Types.ErrorTypes.Unions.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Cart
{
    public class CartNotFoundError : DeleteCartError,PaymentError
    {
        public string? code { get; set; }=nameof(CartNotFoundError);
        public string? message { get; set; } = "Cart not found!";
    }
}
