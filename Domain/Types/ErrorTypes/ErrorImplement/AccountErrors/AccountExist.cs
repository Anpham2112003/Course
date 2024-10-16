using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.AccountErrors
{
    public class AccountExist : CreateAccountError
    {
        public string? code { get; set; } = nameof(AccountExist);
        public string? message { get; set; } = "Account already  exist!";
    }
}
