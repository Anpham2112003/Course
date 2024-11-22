using Domain.Types.ErrorTypes.Unions.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Account
{
    public class AccountNotFound : ForgetPassowordError
    {
        public string? code { get; set; } = nameof(AccountNotFound);
        public string? message { get; set; } = "Account not found!";
    }
}
