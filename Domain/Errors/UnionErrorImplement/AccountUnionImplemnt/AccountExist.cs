using Domain.Errors.UnionError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionErrorImplement.AccountUnionImplemnt
{
    public class AccountExist : CreateAccountError
    {
        public string? code { get; set; } = nameof(AccountExist);
        public string? message { get; set; } = "Account already  exist!";
    }
}
