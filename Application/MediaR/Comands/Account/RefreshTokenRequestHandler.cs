using Domain.DTOs;
using Domain.Interfaces.UnitOfWork;
using Domain.Options;
using Domain.Types.ErrorTypes.BaseError.AccountUnion;
using Domain.Types.ErrorTypes.ErrorImplement.AccountErrors;
using Domain.Untils;
using HotChocolate;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.MediaR.Comands.Account
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, MutationPayload<LoginResponse, RefreshTokenError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOptionsMonitor<JwtOption> _options;

        public RefreshTokenRequestHandler(IUnitOfWork unitOfWork, IOptionsMonitor<JwtOption> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<MutationPayload<LoginResponse, RefreshTokenError>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {


            try
            {
                var errors = new List<RefreshTokenError>();

                var validateToken = Jwt.ValidateRefreshToken(request.Refreshtoken!, _options, out var error, out var claims);

                if (validateToken is false && error)
                {
                    errors.Add(new TokenExpireError());

                    return new MutationPayload<LoginResponse, RefreshTokenError>
                    {
                        errors = errors
                    };
                }

                if (validateToken is false && error is false)
                {
                    errors.Add(new TokenInvalidError());

                    return new MutationPayload<LoginResponse, RefreshTokenError>
                    {
                        errors = errors
                    };
                }

                var email = claims.FindFirstValue(ClaimTypes.Email);

                var account = await _unitOfWork.accountRepository

                    .FindAccountAndRoleAsync(x => x.Email == email, cancellationToken);

                if (account!.IsDeleted)
                {
                    errors.Add(new AccountHasDeleted());

                    return new MutationPayload<LoginResponse, RefreshTokenError>
                    {
                        errors = errors
                    };
                }

                var permissions = account!.roleEntity!.permissionEntities.Select(x => new
                {
                    route = x.Route,
                    state = x.State,
                });

                var jsonPermisson = JsonSerializer.Serialize(permissions, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles,
                });



                var newClaims = new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid,account.Id.ToString()),
                    new Claim(ClaimTypes.Email,email),
                    new Claim(ClaimTypes.Role,account.roleEntity.RoleName!),
                    new Claim("permissions",jsonPermisson),
                };

                var accesstoken = Jwt.GenerateAccessToken(_options, newClaims);

                var refreshtoken = Jwt.GenerateRefreshToken(_options, newClaims);

                account.RefreshToken = refreshtoken;

                _unitOfWork.accountRepository.UpdateOne(account);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<LoginResponse, RefreshTokenError>
                {
                    payload = new LoginResponse
                    {
                        Id = account.Id,
                        Accesstoken = accesstoken,
                        Refreshtoken = refreshtoken
                    }
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
