using Domain.Errors.UnionError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionErrorImplement.AccountUnionImplemnt
{
    public class AccountNotFound : ForgetPassowordError
    {
        public string? code { get; set; } = nameof(AccountNotFound);
        public string? message { get; set; } = "Account not found!";
    }
}
