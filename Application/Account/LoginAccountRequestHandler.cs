using ApplicationCore.Errors;
using ApplicationCore.Untils;
using Domain.DTOs;
using Domain.Entities;
using Domain.Options;
using Domain.Untils;
using HotChocolate;
using Infrastructure.Services.UnitOfWorkService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Account
{
    public class LoginAccountRequestHandler : IRequestHandler<LoginAccountRequest, LoginResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOptionsMonitor<JwtOption> _options;

        public LoginAccountRequestHandler(IUnitOfWork unitOfWork, IOptionsMonitor<JwtOption> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<LoginResponse> Handle(LoginAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _unitOfWork.accountRepository.FindAccountAndRoleAsync(x=>x.Email==request.Email);

                if (account is null || Hash.VerifyHash(account.HashPassword!, request.Password!) is false)
                {
                    throw new GraphQLException(AccountErrors.AccountOrPassowrdError());
                }

                var permissions = account.roleEntity!.permissionEntities.Select(x=> new
                {
                    route =x.Route,
                    state = x.State,
                });

                var jsonPermission = JsonSerializer.Serialize(permissions);

                var Claims = new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid,account.Id.ToString()),
                    new Claim(ClaimTypes.Email,account.Email!),
                    new Claim(ClaimTypes.Role,account.roleEntity.RoleName!),
                    new Claim("permssions",jsonPermission)
                };

                var accesstoken = Jwt.GenerateAccessToken(_options, Claims);

                var refreshtoken = Jwt.GenerateRefreshToken(_options, Claims);

                account.RefreshToken = refreshtoken;

                _unitOfWork.accountRepository.UpdateOne(account);

                await _unitOfWork.SaveChanges(cancellationToken);

                return new LoginResponse
                {
                    Id = account.Id,
                    Accesstoken = accesstoken,
                    Refreshtoken = refreshtoken,
                };
               
            }
            catch (Exception )
            {

                throw ;
            }
        }
    }
}
