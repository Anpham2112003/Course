using Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Untils
{
    public static class Jwt
    {
        public static string GenerateAccessToken(IOptionsMonitor<JwtOption> options , Claim[] claims )
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.CurrentValue.Accesskey!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Sha256);

            var createToken = new JwtSecurityToken(
                    issuer: options.CurrentValue.Issuer,
                    audience: options.CurrentValue.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(options.CurrentValue.AccesskeyExprire)

            );

            var token = new JwtSecurityTokenHandler().WriteToken(createToken);

            return token;
        }


        public static string GenerateRefreshToken(IOptionsMonitor<JwtOption> options, Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.CurrentValue.Refreshkey!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.Sha256);

            var createToken = new JwtSecurityToken(
                    issuer: options.CurrentValue.Issuer,
                    audience: options.CurrentValue.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(options.CurrentValue.RefreshkeyExprire)

            );

            var token = new JwtSecurityTokenHandler().WriteToken(createToken);

            return token;
        }
    }
}
