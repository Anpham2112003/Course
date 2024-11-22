using Domain.Types.ErrorTypes.Unions.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Account
{
    public class AccountExist : CreateAccountError
    {
        public string? code { get; set; } = nameof(AccountExist);
        public string? message { get; set; } = "Account already  exist!";
    }
}
