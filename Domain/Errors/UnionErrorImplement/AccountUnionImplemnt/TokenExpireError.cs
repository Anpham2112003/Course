using Domain.Errors.UnionError.AccountUnion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors.UnionErrorImplement.AccountUnionImplemnt
{
    public class TokenExpireError : RefreshTokenError
    {
        public string? code { get; set; } = nameof(TokenExpireError);
        public string? message { get; set; } = "Token has expired!";
    }
}
