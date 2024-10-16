using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Types.ErrorTypes.ErrorImplement.AccountErrors
{
    public class TokenExpireError : RefreshTokenError
    {
        public string? code { get; set; } = nameof(TokenExpireError);
        public string? message { get; set; } = "Token has expired!";
    }
}
