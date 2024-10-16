using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.AccountErrors
{
    public class AccountHasDeleted : LoginAccountError, RefreshTokenError, ResetPasswordError, ForgetPassowordError, DeleteAccountError
    {
        public string? code { get; set; } = nameof(AccountHasDeleted);
        public string? message { get; set; } = "Account has been deleted!";
    }
}
