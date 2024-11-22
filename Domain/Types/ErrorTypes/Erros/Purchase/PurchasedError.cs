using Domain.Types.ErrorTypes.Unions.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Purchase
{
    public class PurchasedError : CreateCartError
    {
        public string? code { get; set; }=nameof(PurchasedError);
        public string? message { get; set; } = "The course has been purchased!";
    }
}
