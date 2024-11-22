using Domain.Types.ErrorTypes.Unions.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.Erros.Account
{
    public class AccountHasDeleted : LoginAccountError, RefreshTokenError, ResetPasswordError, ForgetPassowordError, DeleteAccountError
    {
        public string? code { get; set; } = nameof(AccountHasDeleted);
        public string? message { get; set; } = "Account has been deleted!";
    }
}
