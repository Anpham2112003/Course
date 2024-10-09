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

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var createToken = new JwtSecurityToken(
                    issuer: options.CurrentValue.Issuer,
                    audience: options.CurrentValue.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(options.CurrentValue.AccesskeyExprire),
                    signingCredentials:credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(createToken);

            return token;
        }


        public static string GenerateRefreshToken(IOptionsMonitor<JwtOption> options, Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.CurrentValue.Refreshkey!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var createToken = new JwtSecurityToken(
                    issuer: options.CurrentValue.Issuer,
                    audience: options.CurrentValue.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(options.CurrentValue.RefreshkeyExpire),
                    signingCredentials:credentials
                    
            );

            var token = new JwtSecurityTokenHandler().WriteToken(createToken);

            return token;
        }

        public static bool ValidateRefreshToken(string token,IOptionsMonitor<JwtOption> options,out bool expire,out ClaimsPrincipal claims)
        {

            try
            {
                var tokenPrameter = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidIssuer = options.CurrentValue.Issuer,
                    ValidAudience = options.CurrentValue.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.CurrentValue.Refreshkey!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    
                };


                var tokenHanler = new JwtSecurityTokenHandler();

                var tokenCliams = tokenHanler.ValidateToken(token, tokenPrameter, out var valid);

                claims = tokenCliams;

                expire=false;

                return true;
            }
            catch (SecurityTokenExpiredException)
            {
                claims=new ClaimsPrincipal();

                expire=true;

                return false;
            }
            catch (Exception )
            {
                claims = new ClaimsPrincipal();

                expire = false;

                return false;

            }

           
            
        }
    }
}
