using Domain.Errors.UnionError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionErrorImplement.AccountUnionImplemnt
{
    public class AccountOrPasswordError : LoginAccountError, ResetPasswordError,DeleteAccountError
    {
        public string? code { get; set; } = nameof(AccountOrPasswordError);
        public string? message { get; set; } = "Account or password incorrect!";
    }
}
