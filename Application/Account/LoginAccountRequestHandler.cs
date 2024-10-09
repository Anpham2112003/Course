﻿
using ApplicationCore.Untils;
using Domain.DTOs;
using Domain.Entities;
using Domain.Errors;
using Domain.Errors.UnionError.AccountUnion;
using Domain.Errors.UnionErrorImplement.AccountUnionImplemnt;
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
    public class LoginAccountRequestHandler : IRequestHandler<LoginAccountRequest, MutationPayload<LoginResponse,LoginAccountError>>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IOptionsMonitor<JwtOption> _options;

        public LoginAccountRequestHandler(IUnitOfWork unitOfWork, IOptionsMonitor<JwtOption> options)
        {
            _unitOfWork = unitOfWork;
            _options = options;
        }

        public async Task<MutationPayload<LoginResponse, LoginAccountError>> Handle(LoginAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var errors = new List<LoginAccountError>();

                var account = await _unitOfWork.accountRepository.FindAccountAndRoleAsync(x=>x.Email==request.Email);

                

                if (account is null || Hash.VerifyHash(account.HashPassword!, request.Password!) is false)
                {
                    errors.Add(new AccountOrPasswordError());


                    return new MutationPayload<LoginResponse, LoginAccountError>
                    {
                        payload = null,
                        errors = errors
                    };
                }

                if (account.IsDeleted)
                {
                    errors.Add(new AccountHasDeleted());

                    return new MutationPayload<LoginResponse, LoginAccountError>
                    {
                        
                        errors = errors
                    };
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

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return new MutationPayload<LoginResponse, LoginAccountError>
                {
                    payload = new LoginResponse
                    {
                        Id = account.Id,
                        Accesstoken = accesstoken,
                        Refreshtoken = refreshtoken,
                    },
                    errors = errors
                };
               
            }
            catch (Exception )
            {

                throw ;
            }
        }
    }
}
