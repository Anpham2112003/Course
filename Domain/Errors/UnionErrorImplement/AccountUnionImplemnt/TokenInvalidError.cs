using Domain.Errors.UnionError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionErrorImplement.AccountUnionImplemnt
{
    public class TokenInvalidError : RefreshTokenError
    {
        public string? code { get; set; } = nameof(TokenInvalidError);
        public string? message { get; set; } = "Token invalid!";
    }
}
